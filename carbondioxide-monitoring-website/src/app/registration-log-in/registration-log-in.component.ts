import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LogIn } from '../models/LogIn';
import { Registration } from '../models/Registration';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-registration-log-in',
  templateUrl: './registration-log-in.component.html',
  styleUrls: ['./registration-log-in.component.css']
})
export class RegistrationLogInComponent implements OnInit {


  sucessfulyLoggedIn:string="";
  unsucessfulyLoggedIn:string="";
  loginMessage:string='';
  constructor(private authService:AuthService,private router:Router) { }

  ngOnInit(): void {
  }

  register(form:NgForm){
    let registrationForm:Registration={
      username:form.value.username,
      password:form.value.password,
      email:form.value.email
    }
    this.authService.register(registrationForm).subscribe(
      (res)=>{this.sucessfulyLoggedIn='Successfuly'},
      (err)=>{this.unsucessfulyLoggedIn='Unsuccessfuly'}
      );
  }

  login(form:NgForm,errorHandler:void){
    let login:LogIn={
      username:form.value.username,
      password:form.value.password
    }
    this.authService.login(login,(msg:string)=>{
      this.loginMessage=msg;
    })
  }

}
