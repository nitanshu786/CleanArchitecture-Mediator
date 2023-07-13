import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from '../Class/register';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Login } from '../Class/login';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  users:any

  // private email = new BehaviorSubject<string>(sessionStorage.getItem("email")!)
  constructor( private httpclient:HttpClient, private route:Router, private jwthealper:JwtHelperService) { }

  Registerservice(reg:Register):Observable<Register>
  {
    debugger;
    return this.httpclient.post<Register>("https://localhost:44339/api/RegisterAPI",reg)
  }

  LoginService(log:any):Observable<any>
  {
    debugger

    return this.httpclient.post<Login>("https://localhost:44339/api/RegisterAPI/Login",log).pipe(map(u=>{

      if(u)
      {
        this.users=u.email
        sessionStorage["userid"]=JSON.stringify(u.id);
        sessionStorage["CurrentUser"]=JSON.stringify(u);
        sessionStorage["Role"]=JSON.stringify(u.role);

      }
      return u;
    }))
    
  }

  sessionitem()
  {
    const item= sessionStorage.getItem("CurrentUsers") as string;
    const data= JSON.parse(item)
    return data;
  }

  logout()
  {
    this.users=""
    sessionStorage.removeItem("CurrentUser")
    sessionStorage.removeItem("Role")
    this.route.navigateByUrl("/login")
  }

  LoginWithGoogle(credentials:any) {
    const header = new HttpHeaders().set('Content-type', 'application/json');
    return this.httpclient.post("https://localhost:44339/api/RegisterAPI/LoginWithGoogle", JSON.stringify(credentials),{ headers: header }).
    pipe(map(u=>{
      if(u)
      {
        this.users=u;
        sessionStorage["CurrentUser"]=JSON.stringify(u);
      }
  return u;
}))
}



public isAuthentication():boolean
{
  if(this.jwthealper.isTokenExpired())
  {
    return false;
  }
  else{
    return true;
  }
}
}
