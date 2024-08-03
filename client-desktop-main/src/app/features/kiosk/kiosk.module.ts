import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { KioskRoutingModule } from './kiosk-routing.module';
import { KioskComponent } from './kiosk.component';
import { MenuComponent } from './components/menu/menu.component';
import { EmergencyMenuComponent } from './components/emergency-menu/emergency-menu.component';
import { CouponCollectScreenComponent } from './components/coupon-collect-screen/coupon-collect-screen.component';
import { CouponPrintComponent } from './components/coupon-print/coupon-print.component';

@NgModule({
  declarations: [
    KioskComponent,
    MenuComponent,
    EmergencyMenuComponent,
    CouponCollectScreenComponent,
    CouponPrintComponent,
  ],
  imports: [
    CommonModule,
    KioskRoutingModule
  ]
})
export class KioskModule { }
