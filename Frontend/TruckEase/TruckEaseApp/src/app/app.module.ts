import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';


import { MaterialModule } from './shared/material.module';
import { PhotoModule } from './components/photos/photo.module';
import { ComponentsModule } from './components/components.module';
import { AppRoutingModule } from './app.routing';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AdminLayoutTransporterModule } from './components/layouts/admin-layout-transporter/admin-layout-transporter.module';
import { RegisterCompanyComponent } from './components/registerCompany/register-company.component';
import { AdminLayoutShipperModule } from './components/layouts/admin-layout-shipper/admin-layout-shipper.module';
import { GlobalSearchComponent } from './components/global-search/global-search.component';
import { EditRequestDialogComponent } from './services/dialogues/edit-transport-request-dialogue/edit-transport-request-dialog.component';
import { MakeOfferDialogComponent } from './services/dialogues/create-transport-offer-dialogue/make-offer-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    EditRequestDialogComponent,
    MakeOfferDialogComponent,
    LoginComponent,
    GlobalSearchComponent,
    RegisterCompanyComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ComponentsModule,
    BrowserAnimationsModule,
    MaterialModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RouterModule,
    PhotoModule,
    AdminLayoutShipperModule,
    AdminLayoutTransporterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
