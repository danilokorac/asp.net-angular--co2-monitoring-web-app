import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationLogInComponent } from './registration-log-in/registration-log-in.component';
import { Co2PollutionCardComponent } from './co2-pollution-card/co2-pollution-card.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { UserMeasurmentsComponent } from './user-measurments/user-measurments.component';

import {JwtModule} from '@auth0/angular-jwt';
import { AddMeasurmentComponent } from './add-measurment/add-measurment.component';
import { StatisticsComponent } from './statistics/statistics.component';

const getTokken=()=>{
  return localStorage.getItem('jwt');
}
@NgModule({
  declarations: [
    AppComponent,
    RegistrationLogInComponent,
    Co2PollutionCardComponent,
    HomeComponent,
    HeaderComponent,
    UserMeasurmentsComponent,
    AddMeasurmentComponent,
    StatisticsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:getTokken,
        allowedDomains:['localhost:44362'],
        disallowedRoutes:[]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
