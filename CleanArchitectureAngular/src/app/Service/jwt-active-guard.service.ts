
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { RegisterService } from './register.service';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';



@Injectable({
  providedIn: 'root'
})
export class JwtActiveGuardService implements CanActivate   {

  constructor(private RegisterService:RegisterService, private route:Router, private JwtActiveGuardService:JwtHelperService) { }

  canActivate(route: ActivatedRouteSnapshot): boolean{
  
   
    if(this.RegisterService.isAuthentication())
    {
      return true;
    }
    else{
      this.route.navigateByUrl("/login")
      return false;
    }
}
}
