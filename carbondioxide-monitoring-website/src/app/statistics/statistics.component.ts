import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Chart, registerables } from 'chart.js';
import { CardModel } from '../models/CardModel';
import { Measurment } from '../models/Measurment';
import { Statistic } from '../models/statistic';
import { MeasurmentsService } from '../services/measurments.service';
Chart.register(...registerables);
@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

    chart:Chart | undefined;
    statistcValues:Measurment[]=[];
    statistcMin:Measurment[]=[];
    statistcMax:Measurment[]=[];
    statistcAverage:number=0;
    locationType:string='';
    
  constructor(private measurmentsService:MeasurmentsService) { }

  ngOnInit(): void {
    
  }

  statisticForm(form:NgForm){

          let startDate:Date=form.value.startDate
          let endDate:Date=form.value.endDate
          let location:string=form.value.location
          let locationType:string=this.locationType=form.value.locationType

    this.measurmentsService.getMeasurementsStatistic('date/'+startDate+'/'+endDate+'/'+locationType+'/'+location).subscribe(res=>{

        this.statistcValues=res.values;
        this.statistcMin=res.min;
        this.statistcMax=res.max;
        this.statistcAverage=res.average;

        let labels:string[]=[];
        let data:number[]=[];

       res.values.forEach((item,index)=>{
           if(locationType!='city')
                labels.push(item.city);
            else
            {
                labels.push(this.numberToMonthName(item.measurementDate));
            }
                
           data.push(item.measurementValue);
        })
        
        if(this.chart!=undefined)
            this.chart.destroy();

        this.chart = new Chart('chart', {
           type: 'bar',
           data: {
                labels: labels,
                datasets: [{
                    label: '# of Votes',
                   data: data,
                   backgroundColor: [
                       'rgba(255, 99, 132, 0.2)',
                       'rgba(54, 162, 235, 0.2)',
                       'rgba(255, 206, 86, 0.2)',
                       'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                   ],
                   borderColor: [
                       'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                   ],
                    borderWidth: 1
               }]
            },
           options: {
                scales: {
                    y: {
                       beginAtZero: true
                    }
                }
            }
        });
    })
  }

  numberToMonthName(newDate:any){
    let monthNames:string[] = ["January", "February", "March", "April", "May","June","July", "August", "September", "October", "November","December"];
    let date = new Date(newDate);
    return newDate.substring(8,10)+' '+monthNames[date.getMonth()] + ' ' + date.getFullYear() ;
  }
}
