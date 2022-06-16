import { Component, OnInit } from '@angular/core';
import { CardModel } from '../models/CardModel';
import { MeasurmentsService } from '../services/measurments.service';

@Component({
  selector: 'app-user-measurments',
  templateUrl: './user-measurments.component.html',
  styleUrls: ['./user-measurments.component.css']
})
export class UserMeasurmentsComponent implements OnInit {
  userMeasurments:CardModel[]=[];
  constructor(private measurmentsService:MeasurmentsService ) { }

  ngOnInit(): void {
    this.measurmentsService.getMeasurements('user').subscribe((data)=>{
      this.userMeasurments=data;
    })
  }
  dateParser(dateAndTime:string){
    let monthNames:string[] = ["January", "February", "March", "April", "May","June","July", "August", "September", "October", "November","December"];
    let date = new Date(dateAndTime);
    return dateAndTime.substring(8,10)+' '+monthNames[date.getMonth()] + ' ' + date.getFullYear();
  }
}
