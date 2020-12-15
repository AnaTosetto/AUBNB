import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserCreateComponent } from './features/user/user-create/user-create.component';
import { NavbarComponent } from './features/navbar/navbar.component';
import { UserService } from './features/user/shared/user.service';
import { ViewHostingComponent } from './features/hosting/view-hosting/view-hosting.component';
import { HostingService } from './features/hosting/shared/hosting.service';
import { DetailHostingComponent } from './features/hosting/detail-hosting/detail-hosting.component';
import { HomeComponent } from './features/home/home.component';
import { LoginComponent } from './features/user/login/login.component';
import { OrderComponent } from './features/order/order.component';
import { HelpComponent } from './features/help/help.component';
import { ProfileComponent } from './features/profile/profile.component';
import { Globals } from './core/globals';
import { NotAuthorizedComponent } from './features/not-authorized/not-authorized.component';
import { UserEditComponent } from './features/user/user-edit/user-edit.component';
import { HostingCreateComponent } from './features/hosting/hosting-create/hosting-create.component';

@NgModule({
  imports: [
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
  ],
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    ViewHostingComponent,
    DetailHostingComponent,
    UserCreateComponent,
    OrderComponent,
    HelpComponent,
    ProfileComponent,
    NotAuthorizedComponent,
    LoginComponent,
    UserEditComponent,
    HostingCreateComponent
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
  ],
  providers: [
    UserCreateComponent,
    UserService,
    HostingService,
    Globals
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
