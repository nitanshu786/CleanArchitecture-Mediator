import { Component,OnInit } from '@angular/core';
import { Validators, AbstractControl, FormBuilder, FormGroup, } from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from 'src/app/Class/register';
import { RegisterService } from 'src/app/Service/register.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  register: Register= new Register();
  GetAll: Register[]=[];
  EditRegister: Register= new Register();
  registrationForm!: FormGroup;
  passwordMismatch: boolean = false;
  passwordLength: boolean = false;

  

  constructor(private RegisterService:RegisterService,private route:Router, private formBuilder:FormBuilder) {}

  get passwords(){return this.registrationForm.get('passwords')}
get confirmPassword(){return this.registrationForm.get('confirmPassword')}


  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      passwords: ['', Validators.required, Validators],
      confirmPassword: ['', Validators.required]
    });
  }

  passwordsMatch(): boolean {
    const password = this.registrationForm.get('passwords')?.value;
    const confirm = this.registrationForm.get('confirmPassword')?.value;
    return password === confirm;
  }
 

 
  Register()
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
debugger
    this.RegisterService.Registerservice( this.register).subscribe(
      (response)=>{      
        Swal.close();
        Swal.fire({
          icon: 'success',
          title: 'Register successfully please login',
          confirmButtonText:'Ok'
        });
        // this.register.username="";
        // this.register.email="";
        // this.register.password="";
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
        });

       }

    )
  }


}

