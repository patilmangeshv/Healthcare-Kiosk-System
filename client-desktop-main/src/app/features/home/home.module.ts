import { NgModule } from '@angular/core';

import { HomeRoutingModule } from './home-routing.module';
import { HomeKioskComponent } from './components/home-kiosk/home-kiosk.component';

@NgModule({
  declarations: [
    HomeKioskComponent
  ],
  imports: [
    HomeRoutingModule
  ],
  exports: [
    HomeKioskComponent,
  ]
})
export class HomeModule { }
