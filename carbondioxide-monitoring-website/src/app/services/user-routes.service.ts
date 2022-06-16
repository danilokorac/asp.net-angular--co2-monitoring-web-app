import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import {JwtHelperService} from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class UserRoutesService implements CanActivate {

  constructor(private jwt:JwtHelperService, private router:Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const token=localStorage.getItem('jwt');

    if(token && !this.jwt.isTokenExpired(token) )
      return true;

      this.router.navigate(['RegistrationLogIn']);
      return false;
  }
}
