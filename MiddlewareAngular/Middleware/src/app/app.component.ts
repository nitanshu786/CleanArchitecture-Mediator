import { Component, OnInit } from '@angular/core';
import { RegisterService } from './Service/register.service';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit  {
  title = 'Middleware';
  isActivate:any;
  constructor(private Service:RegisterService, private route:Router){}

  ngOnInit(): void {
    this.route.events.subscribe(event=>{
      if(event instanceof NavigationEnd){
        let role = sessionStorage.getItem(this.Service.RoleSession)
        this.isActivate=role==='"Admin"';
      }
    })
  }
}


