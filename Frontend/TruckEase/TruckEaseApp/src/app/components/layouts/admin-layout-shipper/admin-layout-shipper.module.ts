import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatRippleModule} from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSelectModule} from '@angular/material/select';
import { ComponentsModule } from '../../components.module';
import { AdminLayoutShipperComponent } from './admin-layout-shipper.component';
import { AdminLayoutShipperRoutingModule } from './admin-layout-shipper.routing';
import { MaterialModule } from '../../../shared/material.module';
import { CreateTransportRequestComponent } from '../../requestTransport/request-transport.component';
import { RequestPageComponent } from '../../requestsPage/request-page.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { CompanyInfoComponent } from '../../company-info/company-info.component';
import { NetworkDirectoryComponent } from '../../network-directory/network-directory.component';
import { CompanyEmployeeComponent } from '../../add-company-employee/company-employee.component';
import { CompanyEmployeePageComponent } from '../../company-employee-page/company-employee-page.component';
import { MatChipsModule } from '@angular/material/chips';
import { ShipperCompanyOffersComponent } from '../../shipper-company-offers/shipper-company-offers.component';
import { ShipperCompanyActiveTransportsComponent } from '../../active-transports-shipper-company/active-transports-shipper-company.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MaterialModule,
    MatSelectModule,
    MatChipsModule,
    MatExpansionModule,
    AdminLayoutShipperRoutingModule,
    MatTooltipModule,
    ComponentsModule,
  ],
  declarations: [
    RequestPageComponent,
    CompanyInfoComponent,
    CreateTransportRequestComponent,
    AdminLayoutShipperComponent,
    NetworkDirectoryComponent,
    ShipperCompanyOffersComponent,
    ShipperCompanyActiveTransportsComponent,
    CompanyEmployeeComponent,
    CompanyEmployeePageComponent

  ]
})

export class AdminLayoutShipperModule {}

