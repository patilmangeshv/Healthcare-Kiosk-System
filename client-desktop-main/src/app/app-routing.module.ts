import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component'

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
    // loadChildren: () => import('./features/home/home.module').then(m => m.HomeModule),
    // canActivate: [AuthGuard]
    //canActivate: [AngularFireAuthGuard], data: { authGuardPipe: redirectUnauthorizedToLogin }
  },
  {
    path: 'kiosk',
    loadChildren: () => import('./features/kiosk/kiosk.module').then(m => m.KioskModule),
  },
  {
    path: 'desk-user',
    loadChildren: () => import('./features/desk-user/desk-user.module').then(m => m.DeskUserModule),
  },

  // {
  //   path: ':lang',
  //   children: [
  //     {
  //       path: 'kiosk',
  //       loadChildren: () => import('./features/kiosk/kiosk.module').then(m => m.KioskModule),
  //     },
  //     {
  //       path: 'desk-user',
  //       loadChildren: () => import('./features/desk-user/desk-user.module').then(m => m.DeskUserModule),
  //     }
  //   ]
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
