import { RegisterService } from 'src/app/Service/register.service';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IntersepterService implements HttpInterceptor {
  constructor(private Service:RegisterService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var curentuser={token:""};
    var currentsession= sessionStorage.getItem(this.Service.SessionItem);
    if(currentsession!=null)
    {
      curentuser= JSON.parse(currentsession);
    }
    req=req.clone({
      setHeaders:{
        
        Authorization:"Bearer "+curentuser
      }
    })
    return next.handle(req)
  }
}

