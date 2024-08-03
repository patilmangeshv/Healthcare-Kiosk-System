import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ConfigService } from '../../../../core/services/config.service';

import { CouponDetail } from '../../models/coupon-details';

@Component({
  selector: 'app-coupon-collect-screen',
  templateUrl: './coupon-collect-screen.component.html',
  styleUrls: ['./coupon-collect-screen.component.css']
})
export class CouponCollectScreenComponent implements OnInit {

  serviceSelected: string = "";
  couponDetails = new CouponDetail();

  constructor(private _router: Router
    , private _route: ActivatedRoute
    , public _configService: ConfigService
  ) { }

  ngOnInit(): void {
    this._route.queryParams
      .subscribe((params: Params) => {
        this.serviceSelected = params["serviceSelected"];

        this.couponDetails = new CouponDetail();

        this.couponDetails.id = params["id"];
        this.couponDetails.serviceCode = params["serviceCode"];
        this.couponDetails.subServiceCode = params["subServiceCode"];
        this.couponDetails.couponGenerationDateTime = params["couponGenerationDateTime"];
        this.couponDetails.zone = params["zone"];
        this.couponDetails.floor = params["floor"];
        this.couponDetails.couponNo = params["couponNo"];
        this.couponDetails.couponNoFormatted = params["couponNoFormatted"];
        this.couponDetails.deskCode = params["deskCode"];
      });
  }
  
  ngAfterViewInit() {
    this.printDocument();
  }

  printDocument() {
    window.print();
  }

  onExitClicked() {
    this._router.navigate(['/'], { relativeTo: this._route });
  }
}
