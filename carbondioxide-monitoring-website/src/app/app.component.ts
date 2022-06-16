import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'carbondioxide-monitoring-website';
  constructor(private router: Router,private authService:AuthService) {}
  ngOnInit(): void {

  }
  
  openRegistrationComponent(pageName:string):void {
    this.router.navigateByUrl(`${pageName}`);
  }
   
  
}
