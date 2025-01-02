/*import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule { }*/

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AdvertisementComponent} from './home/advertisement/advertisement.component';
import {BeautyAndCareComponent} from './beauty-and-care/beauty-and-care.component';
import {ChildcareComponent} from './childcare/childcare.component';
import {DevicesComponent} from './devices/devices.component';
import {DiscountComponent} from './discount/discount.component';
import {InfoComponent} from './info/info.component';
import {NewInComponent} from './new-in/new-in.component';
import {SkinProtectionComponent} from './skin-protection/skin-protection.component';
import {YourHealthComponent} from './your-health/your-health.component';
import {PublicLayoutComponent} from './public-layout/public-layout.component';
import {HomeComponent} from './home/home.component';
import {LoginComponent} from '../auth/login/login.component';
import {WishListComponent} from './wish-list/wish-list.component';


const routes: Routes = [
  {
    path: '', component: PublicLayoutComponent, children: [
      {path: '', redirectTo: 'home', pathMatch: 'full'},

      {path: 'home', component: HomeComponent, children:[
          {path: 'advertisement', component: AdvertisementComponent},
        ]},

      {path: 'beauty-and-care', component: BeautyAndCareComponent},
      {path: 'childcare', component: ChildcareComponent},
      {path: 'devices', component: DevicesComponent},
      {path: 'discount', component: DiscountComponent},
      {path: 'info', component: InfoComponent},
      {path: 'new-in', component: NewInComponent},
      {path: 'skin-protection', component: SkinProtectionComponent},
      {path: 'your-health', component: YourHealthComponent},
      {path: 'login', component: LoginComponent},
      {path: 'wish-list', component: WishListComponent},
      {path: '', redirectTo: 'login', pathMatch: 'full'},
      {path: '**', redirectTo: 'home', pathMatch: 'full'}  // Default ruta koja vodi na public
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule{}
