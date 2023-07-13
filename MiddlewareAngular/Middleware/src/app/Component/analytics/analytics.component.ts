
import { Component, OnInit } from '@angular/core';
import { TimingService } from 'src/app/Service/timing.service';

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.scss']
})
export class AnalyticsComponent implements OnInit {
  executionTimes: number=0;
  constructor(private timingService: TimingService) {}
  
  ngOnInit() {
   this.getTokenTime();
  }
  
  getExecutionTime(method: string): number | undefined {
    return this.timingService.executionTimes[method];
  }

  getTokenTime(){
    debugger
     this.executionTimes= this. timingService.getTokenExecutionTime()
  }
}  
