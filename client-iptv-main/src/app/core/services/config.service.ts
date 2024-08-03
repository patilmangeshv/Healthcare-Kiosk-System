import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private _apiBaseURI: string = "";
  private _appId: string = "";

  constructor(private _http: HttpClient) { }

  public loadConfigSettings() {
    return new Promise((resolve, reject) => {
      this.readJsonConfigSettings().subscribe(res => {
        this._apiBaseURI = (res.apiBaseURI || "");
        this._appId = (res.appId || "");

        resolve(null);
      }, error => {
        console.log('Error while reading config file: ' + error);
        reject(error);
      });
    });
  }

  //Read json file which consist application configuration details 
  private readJsonConfigSettings(): Observable<any> {
    return this._http.get("assets/config/app-config.json");
    // .pipe(map((res: any) => {
    //   return res.json();
    // }));
    // .catch((error: any) => {
    //   return Observable.throw(new Error('Unable to load config settings'));
    // });
  }

  /** Gets the Web Api server's host address*/
  public apiBaseURI() {
    return this._apiBaseURI;
  }

  /**Application ID.*/
  public appId() {
    return this._appId;
  }
}
