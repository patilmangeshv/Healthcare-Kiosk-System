import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ApiDataService } from '../../core/services//apidata.service';
import { AuthService } from '../../core/services/auth.service';
import { BoxServiceIPTV } from '../models/box-service-iptv';

@Injectable({
  providedIn: 'root'
})
export class BoxServiceService {

  constructor(
    private _authService: AuthService,
    private _apiDataService: ApiDataService,
  ) { }

  async getBoxServicesIPTV(deskId: number) {
    let params = new HttpParams().append("DeskId", JSON.stringify(deskId));
    let responseData: any = await this._apiDataService.get("boxservice/boxservices-iptv", params).toPromise();

    let boxesServiceIPTV = new Array<BoxServiceIPTV>();

    if (responseData) {
      for (let index = 0; index < responseData.length; index++) {
        const element = responseData[index];

        let boxServiceIPTV = new BoxServiceIPTV(
          element.id
          , element.boxId, element.boxNo
          , element.serviceId, element.serviceName
          , element.subServiceId
          , element.deskId
          , element.deskCode
          , element.currentCoupon
          , element.totalCoupons
        )

        boxesServiceIPTV.push(boxServiceIPTV);
      }
    }

    return boxesServiceIPTV;
  }
}
