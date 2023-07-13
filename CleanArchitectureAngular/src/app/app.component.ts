import { MatSnackBar } from '@angular/material/snack-bar';
import { NavigationEnd, Router } from '@angular/router';
import { RegisterService } from './Service/register.service';
import { Component, NgZone, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'CleanArchitectureAngular';

  isActivate:any;
  isQuizVisible:Boolean=false;

  constructor(public RegisterService:RegisterService, private route:Router, private NgZone:NgZone,
              private MatSnackBar:MatSnackBar  ){}


  ngOnInit(): void {
    // this.checkQuizVisibility()
    // setInterval(() => {
    //   this.checkQuizVisibility();
    // }, 60000);
    this.route.events.subscribe(event=>{
      if(event instanceof NavigationEnd){
        let role = sessionStorage.getItem('Role')
        this.isActivate=role==='"Admin"';
      }
    })
  }

  logout()
  {
    this.RegisterService.logout();
  }

  // public checkQuizVisibility(): void {
  //   debugger
  //   const now = new Date();
  //   const start = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 15, 35, 0); 
  //   const end = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 20, 15 , 1); 
  
  //   if (now < start || now > end) {
  //     this.isQuizVisible = false;
  //     // this.openSnackBar(`Quiz is timeout Session are Expire?${end} `)
     
  //   } else {
  //     this.isQuizVisible = true;
     

  //   }
  // }
  openSnackBar(message: string) {
    this.MatSnackBar.open(message, 'Close', {
      duration: 3000,
      verticalPosition: 'bottom',
      horizontalPosition: 'center',
      panelClass: 'warning-snackbar'
    });
  }

}
