import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DeskUserComponent } from './desk-user.component';
import { MenuComponent } from './components/menu/menu.component';

const appRoutes: Routes = [
    {
        path: '', component: DeskUserComponent,
        children: [
            { path: 'desk-user-menu', component: MenuComponent },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(appRoutes)],
    exports: [RouterModule],
})
export class DeskUserRoutingModule {
}