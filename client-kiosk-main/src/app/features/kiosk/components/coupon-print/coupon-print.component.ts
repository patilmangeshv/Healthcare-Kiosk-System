import { Component, Input } from '@angular/core';

import { CouponDetail } from '../../models/coupon-details';

@Component({
  selector: 'app-coupon-print',
  templateUrl: './coupon-print.component.html',
  styleUrls: ['./coupon-print.component.css']
})
export class CouponPrintComponent {
  boxn: string | undefined;

  @Input()
  couponDetails = new CouponDetail();

  constructor() { }
}
