import { Component, Input, OnInit } from '@angular/core';
import { CardModel } from '../models/CardModel';

@Component({
  selector: 'app-co2-pollution-card',
  templateUrl: './co2-pollution-card.component.html',
  styleUrls: ['./co2-pollution-card.component.css']
})
export class Co2PollutionCardComponent implements OnInit {
  @Input() 
  card:CardModel={
    measurementValue:550,
    city:'Priboj',
    country:'Serbia',
    measurementDate:'22-4-2022',
    username:''
  };
  constructor() { }

  ngOnInit(): void {
  }
  numberToMonthName(){
    let monthNames:string[] = ["January", "February", "March", "April", "May","June","July", "August", "September", "October", "November","December"];
    let date = new Date(this.card.measurementDate);
    return this.card.measurementDate.substring(8,10)+' '+monthNames[date.getMonth()] + ' ' + date.getFullYear() ;
  }

  getAirQuality(value:number){
    if(value>=300)
      return 'HAZARDOUS';
    else if (value >= 200)
      return 'VERY UNHEALTHY'
    else if (value>=150)
      return 'UNHEALTHY'
    else if (value>=100)
      return 'HIGH RISK'
    else if (value>=50)
      return 'MODERATE'
    else return 'GOOD';
  }

}
