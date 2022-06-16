import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Subject } from 'rxjs';
import { LogIn } from '../models/LogIn';
import { Registration } from '../models/Registration';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public isUerlLoggedIn?:BehaviorSubject<boolean>;
  constructor(private http: HttpClient,private router:Router,private jwt:JwtHelperService) {

  }

  register(registerForm:Registration){
    return this.http.post("https://localhost:44362/api/User/register",registerForm)
  }

  login(loginForm:LogIn,errorHandler:(msg:string)=>void){
    this.http.post("https://localhost:44362/api/User/login",loginForm).subscribe(response=>{
      const token=(<any>response).token;
      localStorage.setItem('jwt',token);
      this.isUerlLoggedIn?.next(true);
      this.router.navigate(['/']);
  },
    err=>{
      errorHandler('Username or Password is not vaild');
    }
  );
  }
  
  logout(){
    localStorage.removeItem('jwt');
    this.isUerlLoggedIn?.next(false);
    this.router.navigate(['/']);
  }

  getIsUerlLoggedIn(){

    if(this.isUerlLoggedIn && !this.checkIsUserStealLoggedIn())
      return this.isUerlLoggedIn;

      let stealLoggedIn=this.checkIsUserStealLoggedIn();
      this.isUerlLoggedIn=new BehaviorSubject<boolean>(stealLoggedIn);

    return this.isUerlLoggedIn;
  }

  checkIsUserStealLoggedIn(){
    let jwtToken=localStorage.getItem('jwt');
    console.log('Hello')
    if(jwtToken!=null && !this.jwt.isTokenExpired(jwtToken))
      return true
    else
      return false;
  }

}
