import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeskUserRoutingModule } from './desk-user-routing.module';
import { MenuComponent } from './components/menu/menu.component';
import { DeskUserComponent } from './desk-user.component';

@NgModule({
  declarations: [
    MenuComponent,
    DeskUserComponent
  ],
  imports: [
    CommonModule,
    DeskUserRoutingModule
  ]
})
export class DeskUserModule { }
