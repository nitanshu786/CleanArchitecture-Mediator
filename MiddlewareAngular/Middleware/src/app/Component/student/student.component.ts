import { Student } from './../../Class/student';
import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/Service/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  Student:Student[]=[];
  newStudent:Student= new Student();
 constructor(private Service:StudentService){}

 ngOnInit(): void {
   this.GetAllStudents();
 }

 GetAllStudents()
 { this.Service.GetAllStudent().subscribe(
      (response)=>{
       this.Student= response
      console.log(this.Student)},
       
      (err)=>{
       alert(err);
      }
    )}

CreateStudent()
{debugger
  this.Service.PostStudent(this.newStudent).subscribe(
    (response)=>{
    this.GetAllStudents()},
    (err)=>{
      alert(err)
    }
  )
}

}
