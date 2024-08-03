import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders,
  HttpParams
} from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthService } from '../services/auth.service';
import { exhaustMap, take } from 'rxjs/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private _authService: AuthService
  ) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this._authService.user.pipe(
      take(1),
      exhaustMap(user => {
        if (request.url == "assets/config/app-config.json") {
          return next.handle(request);
        } else {
          const modifiedRequest = request.clone({
            headers: new HttpHeaders().set("Authorization", "bearer " + user?.token),
            // params: new HttpParams().set("d", "")
          });

          return next.handle(modifiedRequest);
        }
      })
    );
  }
}
