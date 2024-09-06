import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { NavComponent } from './nav/nav.component';
import {  SidebarTransporterComponent } from './layouts/sidebar-transporter/sidebar-transporter.component';
import { MaterialModule } from '../shared/material.module';
import { SidebarShipperComponent } from './layouts/sidebar-shipper/sidebar-shipper.component';



@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule 
  ],
  declarations: [
    FooterComponent,
    NavComponent,
    SidebarTransporterComponent,
    SidebarShipperComponent
  ],
  exports: [
    FooterComponent,
    NavComponent,
    SidebarTransporterComponent,
    SidebarShipperComponent
  ]
})
export class ComponentsModule { }
