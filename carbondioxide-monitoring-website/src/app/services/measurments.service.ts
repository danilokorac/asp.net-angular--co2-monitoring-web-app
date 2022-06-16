import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CardModel } from '../models/CardModel';
import { HttpClient } from '@angular/common/http';
import { Measurment } from '../models/Measurment';
import { Statistic } from '../models/statistic';
@Injectable({
  providedIn: 'root'
})
export class MeasurmentsService {

  constructor(private http: HttpClient) { }

  getMeasurements(url:string): Observable<CardModel[]> {
    return this.http.get<CardModel[]>('https://localhost:44362/api/Measurement/getby/'+url);
  }

  getMeasurementsStatistic(url:string): Observable<Statistic> {
    return this.http.get<Statistic>('https://localhost:44362/api/Measurement/getby/'+url);
  }

  postMeasurements(newMeasurment:Measurment): Observable<any> {
    return this.http.post<any>('https://localhost:44362/api/Measurement/insertmeasurement',newMeasurment);
  }
}

