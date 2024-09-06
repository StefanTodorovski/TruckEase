import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './auth.guard';
import { RegisterCompanyComponent } from './components/registerCompany/register-company.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'register-company',
    component: RegisterCompanyComponent,
  },
  {
    path: 'admin-shipper',
    loadChildren: () => import('./components/layouts/admin-layout-shipper/admin-layout-shipper.module').then(m => m.AdminLayoutShipperModule),
    canActivate: [AuthGuard]

  },
  {
    path: 'admin-transporter',
    loadChildren: () => import('./components/layouts/admin-layout-transporter/admin-layout-transporter.module').then(m => m.AdminLayoutTransporterModule),
    canActivate: [AuthGuard]

  },
  {
    path: '**',
    redirectTo: 'login',
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: false
    })
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
