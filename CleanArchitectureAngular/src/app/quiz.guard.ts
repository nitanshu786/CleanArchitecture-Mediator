import { Injectable, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuizGuard implements CanActivate  {

  constructor(private router:Router){}

 
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree {
      const now = new Date();
      const start = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 10, 11, 0);
      const end = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 20, 0, 1);
  
      if (now < start || now > end) {
        
        return this.router.createUrlTree(['/']);
      }
  
      return true; 
    }
  
  
}
