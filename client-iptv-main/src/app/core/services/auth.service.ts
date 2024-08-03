import { stringify } from '@angular/compiler/src/util';
import { Injectable } from '@angular/core';
import { BehaviorSubject, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { Login } from '../models/login';
import { User } from '../models/user';
import { ApiDataService } from './apidata.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  /**
   * Reactive property for accessing user change.
   */
  user = new BehaviorSubject<User | null>(null);

  constructor(private _apiDataService: ApiDataService) { }

  login(login: Login) {
    return this._apiDataService.post("account/login", login)
      .pipe(
        // without altering the reposnse, store it for local purpose
        tap((responseData: any) => {
          const userData = new User(responseData.username, responseData.deskId, responseData.deskCode
            , responseData.boxId, responseData.boxNo, responseData.token);
          this.user.next(userData);

          localStorage.setItem("userData", JSON.stringify(userData));
        }),
        // catch error and process it here. all logic of error processing will be done here instead 
        // multiple caller have same logic.
        catchError(errorResponse => {
          let errorMessage = "An unknown error occured!";

          if (errorResponse.error)
            errorMessage = errorResponse.error;
          else
            console.log(errorResponse); // temporary log exeception to console

          return throwError(errorMessage);
        }));
  }

  autoLogin() {
    const data = localStorage.getItem("userData");
    if (data) {
      const userData: {
        username: string,
        deskId: number,
        deskCode: string,
        boxId: number,
        boxNo: string,
        token: string
      } = JSON.parse(data);

      const loadedData = new User(userData.username, userData.deskId, userData.deskCode
        , userData.boxId, userData.boxNo, userData.token);
      this.user.next(loadedData);
    }
  }

  logout() {
    this.user.next(null);
    localStorage.removeItem("userData");
  }

  getDesks() {
    return this._apiDataService.get("desk");
      // .pipe(
      //   // catch error and process it here. all logic of error processing will be done here instead 
      //   // multiple caller have same logic.
      //   catchError(errorResponse => {
      //     let errorMessage = "An unknown error occured!";

      //     if (errorResponse.error)
      //       errorMessage = errorResponse.error;
      //     else
      //       console.log(errorResponse); // temporary log exeception to console

      //     return throwError(errorMessage);
      //   }));
  }
}
