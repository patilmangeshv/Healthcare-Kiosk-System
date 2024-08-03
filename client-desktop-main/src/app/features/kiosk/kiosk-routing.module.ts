import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { KioskComponent } from './kiosk.component';
import { MenuComponent } from './components/menu/menu.component';
import { EmergencyMenuComponent } from './components/emergency-menu/emergency-menu.component';
import { CouponCollectScreenComponent } from './components/coupon-collect-screen/coupon-collect-screen.component';
import { CouponPrintComponent } from './components/coupon-print/coupon-print.component';

const routes: Routes = [
  {
    path: '', component: KioskComponent,
    children: [
      { path: 'kiosk-menu', component: MenuComponent },
      { path: 'kiosk-coupon-collect', component: CouponCollectScreenComponent },
      { path: 'kiosk-emergency-menu', component: EmergencyMenuComponent },
      { path: 'kiosk-coupon-print', component: CouponPrintComponent },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KioskRoutingModule { }
