import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeKioskComponent } from './components/home-kiosk/home-kiosk.component';

const appRoutes: Routes = [
    // default route should be removed after login functionality implemented.
    { path: '', redirectTo: '/kiosk', pathMatch: 'full' },
    { path: 'kiosk', component: HomeKioskComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule],
})
export class HomeRoutingModule {
}