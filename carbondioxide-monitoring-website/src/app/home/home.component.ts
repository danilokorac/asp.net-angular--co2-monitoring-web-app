import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CardModel } from '../models/CardModel';
import { MeasurmentsService } from '../services/measurments.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  fetchedData:CardModel[]=[];
  constructor(private measurmentsService:MeasurmentsService) { }

  ngOnInit(): void {
    this.measurmentsService.getMeasurements('date/newest').subscribe(data=>{
      this.fetchedData=data;
      console.log(this.fetchedData);
    })
  }
  cityForm(form:NgForm){
    let city:string=form.value.city;
    console.log(city);

    this.measurmentsService.getMeasurements('city/'+city).subscribe(data=>{
      this.fetchedData=data;
    })
  }

  countryForm(form:NgForm){
    let country:string=form.value.country;
    console.log(country);

    this.measurmentsService.getMeasurements('country/'+country).subscribe(data=>{
      console.log(data);
      this.fetchedData=data;
    })
  }

  measurementsForm(form:NgForm){
    let ppm:string=form.value.ppm;
    console.log(form.value);

    this.measurmentsService.getMeasurements('measurement/'+ppm).subscribe(data=>{
      console.log(data);
      this.fetchedData=data;
    })
  }

  dateForm(form:NgForm){
    let date:string=form.value.date;
    console.log(form.value);

    this.measurmentsService.getMeasurements('date/'+date).subscribe(data=>{
      console.log(data);
      this.fetchedData=data;
    })
  }

}
