import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DetailHostingComponent } from './features/hosting/detail-hosting/detail-hosting.component';
import { ViewHostingComponent } from './features/hosting/view-hosting/view-hosting.component';
import { HomeComponent } from './features/home/home.component';
import { UserCreateComponent } from './features/user/user-create/user-create.component';
import { OrderComponent } from './features/order/order.component';
import { HelpComponent } from './features/help/help.component';
import { ProfileComponent } from './features/profile/profile.component';
import { LoginComponent } from './features/user/login/login.component';
import { NotAuthorizedComponent } from './features/not-authorized/not-authorized.component';
import { UserEditComponent } from './features/user/user-edit/user-edit.component';
import { HostingCreateComponent } from './features/hosting/hosting-create/hosting-create.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  { path: 'detail-hosting/:id', component: DetailHostingComponent },
  { path: 'view-hosting', component: ViewHostingComponent },
  { path: 'create-hosting', component: HostingCreateComponent },
  { path: 'login', component: LoginComponent},
  { path: 'user', component: UserCreateComponent},
  { path: 'order', component: OrderComponent},
  { path: 'help', component: HelpComponent},
  { path: 'profile', component: ProfileComponent},
  { path: 'user-edit', component: UserEditComponent},
  { path: 'not-authorized', component: NotAuthorizedComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
