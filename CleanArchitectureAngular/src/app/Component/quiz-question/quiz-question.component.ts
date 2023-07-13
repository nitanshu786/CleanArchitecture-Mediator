import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { QuizQuestion } from 'src/app/Class/quiz-question';
import { QuizService } from 'src/app/Service/quiz.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-quiz-question',
  templateUrl: './quiz-question.component.html',
  styleUrls: ['./quiz-question.component.scss']
})
export class QuizQuestionComponent implements OnInit {


  GetAll:QuizQuestion[]=[]
  newquestion:QuizQuestion= new QuizQuestion();
  editquestion:QuizQuestion= new QuizQuestion();


  constructor(private QuizService:QuizService, private routes:Router){}

  ngOnInit(): void {
    this.GetAllQuestion();
  }

  GetAllQuestion()
  {
    this.QuizService.GetAllAdmin().subscribe(
      (response)=>{
  this.GetAll=response
  console.log(this.GetAll)
      },
      (err)=>{
     alert(err);
      }
    )
  }

  CreateClick()
  {
    debugger;
    this.QuizService.CreateQuestion(this.newquestion). subscribe(
      (response)=>{
        Swal.fire({
          icon: 'success',
          title: 'Data saved successfully',
          showConfirmButton: false,
          timer: 1500,
        }),
        this.GetAllQuestion();
       this.newquestion.question="";
       this.newquestion.option1="";
       this.newquestion.option2="";
       this.newquestion.option3=""
       this.newquestion.option4=""
       this.newquestion.correctAnswer=""

      },
      (error)=>{
        console.log(error)
      }
    )
  }
  EditClick(data:QuizQuestion){
    this.editquestion=data
    
  }
  Updateclick()
  {
    this.QuizService.UpdateQuestion(this.editquestion).subscribe(
      (response)=>{
        Swal.fire({
          icon: 'success',
          title: 'Data Updated successfully',
          showConfirmButton: false,
          timer: 1500
        }),
        this.GetAllQuestion();
        this.newquestion.question="";
       this.newquestion.option1="";
       this.newquestion.option2="";
       this.newquestion.option3=""
       this.newquestion.option4=""
       this.newquestion.correctAnswer=""
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  DeleteClick(id:Number){  
  Swal.fire({  
    title: 'Are you sure want to remove?',  
    text: 'You will not be able to recover this file!',  
    icon: 'warning',  
    showCancelButton: true,  
    confirmButtonText: 'Yes, delete it!',  
    cancelButtonText: 'No, keep it'  
  }).then((result) => {  
    if (result.value)
    {
      this.QuizService.DeleteQuestion(id).subscribe(
        (response)=>{
          this.GetAllQuestion();
        })

      Swal.fire(  
        'Deleted!',  
        'Your imaginary file has been deleted.',  
        'success'  
      )  
    } else if (result.dismiss === Swal.DismissReason.cancel) {  
      Swal.fire(  
        'Cancelled',  
        'Your imaginary file is safe :)',  
        'error'  
      )  
    }  
  })  
} 
}
