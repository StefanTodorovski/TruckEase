import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutShipperComponent } from './admin-layout-shipper.component';
import { ProfileComponent } from '../../profile/profile.component';
import { NgModule } from '@angular/core';
import { CreateTransportRequestComponent } from '../../requestTransport/request-transport.component';
import { RequestPageComponent } from '../../requestsPage/request-page.component';
import { GlobalSearchComponent } from '../../global-search/global-search.component';
import { CompanyInfoComponent } from '../../company-info/company-info.component';
import { NetworkDirectoryComponent } from '../../network-directory/network-directory.component';
import { CompanyEmployeeComponent } from '../../add-company-employee/company-employee.component';
import { CompanyEmployeePageComponent } from '../../company-employee-page/company-employee-page.component';
import { ShipperCompanyOffersComponent } from '../../shipper-company-offers/shipper-company-offers.component';
import { ShipperCompanyActiveTransportsComponent } from '../../active-transports-shipper-company/active-transports-shipper-company.component';


const AdminLayoutShipperRoutes: Routes = [
  {
    path: '',
    component: AdminLayoutShipperComponent,
    children: [
      { path: '', redirectTo: 'all-requests', pathMatch: 'full'},
      {
        path: 'admin-shipper',
        component: AdminLayoutShipperComponent,
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
        component: RequestPageComponent,
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
        component: ShipperCompanyOffersComponent,
      },
      {
        path: 'active-transports',
        component: ShipperCompanyActiveTransportsComponent,
      }
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(AdminLayoutShipperRoutes)
  ],
  exports: [RouterModule]
})
export class AdminLayoutShipperRoutingModule { }