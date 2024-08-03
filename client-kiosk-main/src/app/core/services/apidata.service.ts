import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { ConfigService } from './config.service';

const httpPostOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'access-control-allow-origin': '*'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiDataService {

  constructor(private _http: HttpClient, private _configService: ConfigService) { }

  public get(url: string) {
    let requesteUrl = this._configService.apiBaseURI() + url;

    return this._http.get(requesteUrl);
  }

  public post(url: string, body?: any) {
    let requesteUrl = this._configService.apiBaseURI() + url;

    return this._http.post(requesteUrl, body, httpPostOptions);
  }
}
