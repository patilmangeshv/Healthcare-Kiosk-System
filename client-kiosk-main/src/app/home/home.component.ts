import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ApiDataService } from '../core/services/apidata.service';
import { ConfigService } from '../core/services/config.service';
import { CouponDetail } from '../features/kiosk/models/coupon-details';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private _router: Router
    , private _route: ActivatedRoute
    , public _configService: ConfigService
    , private _apiDataService: ApiDataService
  ) { }

  ngOnInit(): void {
  }

  async onOptionSelect(optionSelected: string) {
    let navigateTo = "";
    let couponDetails: CouponDetail | undefined;

    switch (optionSelected) {
      case "information":
      case "payment-desk":
        navigateTo = "./kiosk/kiosk-coupon-collect";
        break;
      case "emergency":
        navigateTo = "./kiosk/kiosk-emergency-menu";
        break;
      case "take-appointment":
      case "have-appointment":
      case "recover-results":
        // navigateTo = "../kiosk-coupon-w-patient";
        break;

      default:
        break;
    }

    if (navigateTo !== "") {
      if (navigateTo == "./kiosk/kiosk-coupon-collect") {
        couponDetails = await this.generateCoupon(optionSelected);

        await this._router.navigate([navigateTo], {
          relativeTo: this._route
          , queryParams: {
            serviceSelected: optionSelected,
            id: couponDetails.id,
            serviceCode: couponDetails.serviceCode,
            subServiceCode: couponDetails.subServiceCode,
            couponGenerationDateTime: couponDetails.couponGenerationDateTime,
            zone: couponDetails.zone,
            floor: couponDetails.floor,
            couponNo: couponDetails.couponNo,
            couponNoFormatted: couponDetails.couponNoFormatted,
            deskCode: couponDetails.deskCode
          }
        });
      } else {
        await this._router.navigate([navigateTo], {
          relativeTo: this._route
          , queryParams: {
            serviceSelected: optionSelected
          }
        });
      }
    }
  }

  async generateCoupon(serviceSelected: string) {
    let serviceCode: string = "";
    let subServiceCode!: string;
    let kioskId: number = 1;

    switch (serviceSelected) {
      case "information":
        serviceCode = "INFO";
        subServiceCode = "";
        break;
      case "payment-desk":
        serviceCode = "CMASSPCMCJ";
        subServiceCode = "";
        break;
      // HAS SUB SERVICE MENU
      // case "emergency":
      //   serviceCode = "";
      //   subServiceCode = "";
      //   break;
      case "take-appointment":
        serviceCode = "";
        subServiceCode = "";
        break;
      case "have-appointment":
        serviceCode = "";
        subServiceCode = "";
        break;
      case "recover-results":
        serviceCode = "";
        subServiceCode = "";
        break;
      case "emg-have-yellow-card":
        serviceCode = "";
        subServiceCode = "";
        break;
      case "emg-yellow-form-request":
        serviceCode = "DHSE";
        subServiceCode = "DHSE-URG";
        break;
      case "emg-information-emergency":
        serviceCode = "DHSE";
        subServiceCode = "DHSE-URG";
        break;
      case "emg-payment-desk":
        serviceCode = "";
        subServiceCode = "";
        break;
      default:
        break;
    }
    let responseData: any = await this._apiDataService.post("coupon/create-coupon"
      , { serviceCode: serviceCode, subServiceCode: subServiceCode, kioskId: kioskId }).toPromise();

    let couponDetails = new CouponDetail();

    if (responseData) {
      for (let index = 0; index < responseData.length; index++) {
        const element = responseData[index];

        couponDetails.id = element.id;
        couponDetails.floor = element.floor;
        couponDetails.zone = element.zone;
        couponDetails.deskCode = element.deskCode;
        couponDetails.serviceCode = element.serviceCode;
        couponDetails.subServiceCode = element.subServiceCode;
        couponDetails.couponNo = element.couponNo;
        couponDetails.couponGenerationDateTime = element.couponGenerationDateTime;
        couponDetails.couponNoFormatted = element.couponNoFormatted;
      }
    }

    return couponDetails;
  }

  onBackClicked() {
    this._router.navigate(['/'], { relativeTo: this._route });
  }
}
