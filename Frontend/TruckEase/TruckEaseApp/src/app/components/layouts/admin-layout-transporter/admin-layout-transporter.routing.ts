import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutTransporterComponent } from './admin-layout-transporter.component';
import { NgModule } from '@angular/core';
import { ProfileComponent } from '../../profile/profile.component';
import { CreateTransportRequestComponent } from '../../requestTransport/request-transport.component';
import { RequestPageComponent } from '../../requestsPage/request-page.component';
import { GlobalSearchComponent } from '../../global-search/global-search.component';
import { CompanyInfoComponent } from '../../company-info/company-info.component';
import { NetworkDirectoryComponent } from '../../network-directory/network-directory.component';
import { CompanyEmployeeComponent } from '../../add-company-employee/company-employee.component';
import { CompanyEmployeePageComponent } from '../../company-employee-page/company-employee-page.component';
import { TransporterRequestPageComponent } from '../../transporter-requests-page/transporter-request-page.component';
import { TransporterCompanyOffersComponent } from '../../transporter-company-offers/transporter-company-offers.component';
import { TransporterCompanyActiveTransportsComponent } from '../../active-transports-transporter-company/active-transports-transporter-company.component';

const AdminLayoutRoutes: Routes = [
  {
    path: '',
    component: AdminLayoutTransporterComponent,
    children: [
      { path: '', redirectTo: 'profile', pathMatch: 'full'},
      {
        path: 'admin-transporter',
        component: AdminLayoutTransporterComponent,
      },
      {
        path: 'profile',
        component: ProfileComponent,
      },
      {
        path: 'create-request',
        component: CreateTransportRequestComponent,
      },
      {
        path: 'all-requests',
        component: TransporterRequestPageComponent,
      },
      {
        path: 'global-search',
        component: GlobalSearchComponent,
      },
      {
        path: 'company-info',
        component: CompanyInfoComponent,
      },
      {
        path: 'supply-chain',
        component: NetworkDirectoryComponent,
      },
      {
        path: 'create-employee',
        component: CompanyEmployeeComponent,
      },
      {
        path: 'employees',
        component: CompanyEmployeePageComponent,
      },
      {
        path: 'offers',
        component: TransporterCompanyOffersComponent,
      },
      {
        path: 'active-transports',
        component: TransporterCompanyActiveTransportsComponent,
      }
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(AdminLayoutRoutes)
  ],
  exports: [RouterModule]
})
export class AdminTransporterRoutingModule { }