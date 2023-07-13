import { TimingService } from 'src/app/Service/timing.service';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Router } from '@angular/router';
import { Register } from '../Class/register';
import { Login } from '../Class/login';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  public readonly SessionItem="CurrentUsers"
  public readonly RoleSession="Role"
  token:any;
  constructor( private httpclient:HttpClient, private route:Router, private TimingService:TimingService, private jwthelper:JwtHelperService) { }
   
  Registerservice(reg:any):Observable<any>
  {
    return this.httpclient.post<any>("https://localhost:7247/api/RegisterApi",reg)
  }
  
  LoginService(log: any): Observable<any> {
  
    return this.httpclient.post<any>('https://localhost:7247/api/RegisterApi/Login', log, { observe: 'response' })
      .pipe(
        map((response: HttpResponse<any>) => {
          const tokenData = response.body.result;
          this.token=tokenData.token
           sessionStorage.setItem(this.SessionItem,JSON.stringify(tokenData.token));
           const role= this.TokenDecrypter();
           sessionStorage.setItem(this.RoleSession,JSON.stringify(role))
           this.TimingService.AddTokenTime(tokenData.tokenCreationTime)
          return { tokenData, user: response.body };
        })
      );
  }

 

  logout()
  {
    sessionStorage.removeItem("CurrentUser")
    sessionStorage.removeItem("Role")
    this.route.navigateByUrl("/login")
  }


  TokenDecrypter()
  {
    const decodedToken = this.jwthelper.decodeToken(this.token);
    return decodedToken.role;
  }


// public isAuthentication():boolean
// {
//   if(this.jwthealper.isTokenExpired())
//   {
//     return false;
//   }
//   else{
//     return true;
//   }
// }
}
