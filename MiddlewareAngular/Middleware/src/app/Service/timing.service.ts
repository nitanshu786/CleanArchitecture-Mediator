
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TimingService {
  private readonly STORAGE_KEY = 'executionTimes';
  private readonly TokenKey = 'CreationTime';
  executionTimes: { [key: string]: number } = {};
  private Tokentime: number=0;

  
  constructor() {
    this.loadExecutionTimes();
    this.GetLocalItem();
  }



  private GetLocalItem()
  { const ms= localStorage.getItem(this.TokenKey);
    if(ms){
      this.Tokentime= JSON.parse(ms)
    }}

  private loadExecutionTimes() {
    const executionTimesString = localStorage.getItem(this.STORAGE_KEY);
    if (executionTimesString) {
      this.executionTimes = JSON.parse(executionTimesString);
    }
  }

  addExecutionTime(method: any, time: number) {
    this.executionTimes[method] = time;
    this.saveExecutionTimes();
  }
  private saveExecutionTimes() {
    localStorage.removeItem(this.STORAGE_KEY);
    const executionTimesString = JSON.stringify(this.executionTimes);
    localStorage.setItem(this.STORAGE_KEY, executionTimesString);
  }

  
  AddTokenTime(time: number) {
     this.Tokentime= time;
    this. TokenSession();
  }

  private TokenSession()
  { const time= JSON.stringify(this.Tokentime);
    localStorage.setItem(this.TokenKey, time);
  }

  getTokenExecutionTime(): number  {
    return this.Tokentime;
  }
 

}
