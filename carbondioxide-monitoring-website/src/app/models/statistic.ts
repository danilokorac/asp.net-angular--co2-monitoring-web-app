import { Measurment } from "./Measurment";

export interface Statistic{
    values:Measurment[],
    min:Measurment[],
    max:Measurment[],
    average:number
}