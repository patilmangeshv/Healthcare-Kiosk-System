import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-coupon-print',
  templateUrl: './coupon-print.component.html',
  styleUrls: ['./coupon-print.component.css']
})
export class CouponPrintComponent implements OnInit {
  date: Date | undefined;
  boxn: string | undefined;
  ticketn: string | undefined;
  barCodeValue: string = '123456';
  etage: string | undefined;
  axe: string | undefined;
  desk: string | undefined;
  service: string | undefined;

  constructor() { }

  ngOnInit(): void {

    this.date = new Date()
    this.boxn = 'A11';
    this.ticketn = '001';
    // this.barCodeValue = 1234;
    this.etage = 'NO';
    this.axe = "ABC";
    this.desk = "S12";
    this.service = 'INF'
  }

}
