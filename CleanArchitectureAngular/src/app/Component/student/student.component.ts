import { Router } from '@angular/router';
import { StudentService } from './../../Service/student.service';
import { RegisterService } from './../../Service/register.service';
import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/Class/student';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  newstudent:Student= new Student();
  GetAllStudent:Student[]=[];
  Update:Student= new Student();

  constructor(private StudentService:StudentService, private route:Router, private RegisterService:RegisterService){}
  ngOnInit(): void {
    this.getALL();
  }

  getALL()
  {
    this.StudentService.GetAllStudentService().subscribe(
      (respnse)=>{
       this.GetAllStudent=respnse;
       console.log(this.GetAllStudent);
      },
      (error)=>{
      this.RegisterService.logout();
         this.route.navigateByUrl("/login")
      }
    )
    }

    CreateClick()
  {
    debugger;
    this.StudentService.CreateStudentService(this.newstudent). subscribe(
      (response)=>{
        this .getALL();
       this.newstudent.name="";
       this.newstudent.address="";
       this.newstudent.email="";
       this.newstudent.contact=""
      },
      (error)=>{
        console.log(error)
      }
    )
  }
  EditClick(student:Student){
    this.Update=student
    
  }
  Updateclick()
  {
    this.StudentService.UpdateStudentService(this.Update).subscribe(
      (response)=>{
        this.getALL();
        this.Update.name="";
        this.Update.address="";
        this.Update.email="";
        this.Update.contact="";

      },
      
      (error)=>{
        console.log(error);
      }
    )
  }
  DeleteClick(id:number)
  {
    this.StudentService.DeleteStudentService(id).subscribe(
      (response)=>{
        this.getALL();
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
