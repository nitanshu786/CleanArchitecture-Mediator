import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { RegisterService } from 'src/app/Service/register.service';
import { Router } from '@angular/router';
import { Login } from 'src/app/Class/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  newlogin:Login= new Login();
  loginForm!: FormGroup;
  Data:any;
  array:Login[]=[]
  executionTime: number | undefined;
constructor(private RegisterService:RegisterService, private route:Router, private formBuilder:FormBuilder) {}

ngOnInit(): void {
  this.loginForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });
  
}



    
login()
{
  Swal.fire({
    title: 'Please wait!',
    customClass: '.swal2-progresssteps',
    timerProgressBar: true,
    timer: 15000,
    didOpen: () => {
      Swal.showLoading();
    }
  });
  this.RegisterService.LoginService(this.newlogin).subscribe(
    (response)=>{
      this.executionTime = response.user.tokenCreationTime;
      this.Data = response.user.result.email;
      console.log(this.executionTime)
      Swal.close();
      Swal.fire({
        title: `🎉 Welcome ${this.Data}! 🎊`,
        text: 'You have successfully logged in.',
        confirmButtonText: 'Ok',
        showClass: {
          popup: 'swal2-noanimation',
          backdrop: 'swal2-noanimation'
        },
        hideClass: {
          popup: '',
          backdrop: ''
        }
      });
     this.newlogin.email="";
     this.newlogin.password="";
    this.route.navigateByUrl("/home")
    },
    (error)=>{
       console.log(error);
       Swal.close();
       Swal.fire({
        icon: 'warning',
        title: 'Not exist',
        confirmButtonText:'Ok'
    }
  )
  })
}
}
