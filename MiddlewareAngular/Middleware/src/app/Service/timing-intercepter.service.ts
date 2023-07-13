
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { TimingService } from './timing.service';

@Injectable({
  providedIn: 'root'
})
export class TimingIntercepterService implements HttpInterceptor {
  constructor(private timingService: TimingService) {}
  
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const startTime = performance.now();
    return next.handle(request).pipe(
      tap((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          const endTime = performance.now();
          const executionTime = endTime - startTime 
          const url= request.url+"/"+request.method;
          this.timingService.addExecutionTime(url, executionTime);
          console.log(url);
        }
      })
    );
  }

}
