import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IntersepterService  {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var curentuser={token:""};
    debugger
    var currentsession= sessionStorage.getItem("CurrentUser");
    if(currentsession!=null)
    {
      curentuser= JSON.parse(currentsession);
    }
    req=req.clone({
      setHeaders:{
        Authorization:"Bearer "+curentuser.token
      }
    })
    return next.handle(req)
  }
}
