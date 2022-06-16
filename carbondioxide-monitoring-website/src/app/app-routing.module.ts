import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationLogInComponent } from '../app/registration-log-in/registration-log-in.component';
import { AddMeasurmentComponent } from './add-measurment/add-measurment.component';
import { HomeComponent } from './home/home.component';
import { UserRoutesService } from './services/user-routes.service';
import { StatisticsComponent } from './statistics/statistics.component';
import { UserMeasurmentsComponent } from './user-measurments/user-measurments.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'RegistrationLogIn', component: RegistrationLogInComponent},
  {path:'user/measurment/list', component:UserMeasurmentsComponent, canActivate:[UserRoutesService]},
  {path:'user/measurment/add',component:AddMeasurmentComponent, canActivate:[UserRoutesService]},
  {path:'statistics', component:StatisticsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
