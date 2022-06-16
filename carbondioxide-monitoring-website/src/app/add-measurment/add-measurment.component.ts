import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CardModel } from '../models/CardModel';
import { Measurment } from '../models/Measurment';
import { MeasurmentsService } from '../services/measurments.service';

@Component({
  selector: 'app-add-measurment',
  templateUrl: './add-measurment.component.html',
  styleUrls: ['./add-measurment.component.css']
})
export class AddMeasurmentComponent implements OnInit {
  sucessfulyInserted:string="";
  unsucessfulyInserted:string="";
  constructor(private measurmentsServer:MeasurmentsService) { }

  ngOnInit(): void {
  }

  addMeasurment(form:NgForm){
    let measurment:Measurment={
      measurementValue:form.value.value,
      city:form.value.city,
      country:form.value.country,
      measurementDate:form.value.date,
    }

    this.measurmentsServer.postMeasurements(measurment).subscribe(
    res=>{
      this.sucessfulyInserted='Successfuly';
      this.unsucessfulyInserted=''
    },
    err=>{
      this.unsucessfulyInserted='Unseccessfuly';
      this.sucessfulyInserted='';
  });
  }

}
