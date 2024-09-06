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
import { ProfileComponent } from '../../profile/profile.component';
import { AdminTransporterRoutingModule } from './admin-layout-transporter.routing';
import { AdminLayoutTransporterComponent } from './admin-layout-transporter.component';
import { MaterialModule } from '../../../shared/material.module';
import { TransporterRequestPageComponent } from '../../transporter-requests-page/transporter-request-page.component';
import { TransporterCompanyOffersComponent } from '../../transporter-company-offers/transporter-company-offers.component';
import { TransporterCompanyActiveTransportsComponent } from '../../active-transports-transporter-company/active-transports-transporter-company.component';

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
    AdminTransporterRoutingModule,
    MatTooltipModule,
    ComponentsModule,
  ],
  declarations: [
    ProfileComponent,
    TransporterRequestPageComponent,
    TransporterCompanyActiveTransportsComponent,
    TransporterCompanyOffersComponent,
    AdminLayoutTransporterComponent

  ]
})

export class AdminLayoutTransporterModule {}
