// ANGULAR ROUTER MODULE
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { AdminComponent } from './components/admin/admin.component';

const APP_ROUTES: Routes = [
    {path: 'main', component: MainComponent},
    {path: 'admin', component: AdminComponent},
    {path: '**', pathMatch: 'full' , redirectTo: 'main'}
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, { useHash: true });
