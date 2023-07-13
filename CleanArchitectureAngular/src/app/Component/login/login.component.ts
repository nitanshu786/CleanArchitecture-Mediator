import { RegisterService } from './../../Service/register.service';
import { Component, OnInit,NgZone } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CredentialResponse } from 'google-one-tap';
import { Login } from 'src/app/Class/login';
import Swal from 'sweetalert2';

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
  constructor(private RegisterService:RegisterService, private route:Router, private formBuilder:FormBuilder,private _ngZone: NgZone) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
     // @ts-ignore
     window.onGoogleLibraryLoad = () => {
      // @ts-ignore
      google.accounts.id.initialize({
        client_id:'138132666430-i4baaoiobpordv658dnfrc6t9d0tpg6m.apps.googleusercontent.com',
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true
      });
      // @ts-ignore
      google.accounts.id.renderButton(
      // @ts-ignore
      document.getElementById("buttonDiv"),
        { theme: "outline", size: "large", width: "100%" } 
      );
      // @ts-ignore
      google.accounts.id.prompt((notification: PromptMomentNotification) => {});
    };
  }
  async handleCredentialResponse(response: CredentialResponse) {
    debugger
    await this.RegisterService.LoginWithGoogle(response.credential).subscribe(
      (x:any) => {
      
        this._ngZone.run(() => {
          this.route.navigate(["/home"]);
        })},
      (error:any) => {
          alert("not login ")
        }
      ); 
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
debugger
        this.Data = this.RegisterService.users
        console.log()
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
        debugger
         console.log(error);
         Swal.close();
         Swal.fire({
          icon: 'warning',
          title: 'User already exist',
          confirmButtonText:'Ok'
      }
    )
    })
}
}
