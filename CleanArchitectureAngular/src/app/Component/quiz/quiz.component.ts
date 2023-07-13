import { QuizService } from './../../Service/quiz.service';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import {  answerclass } from 'src/app/Class/answerclass';
import { QuizQuestion } from 'src/app/Class/quiz-question';
import { Userseleted } from 'src/app/Class/userseleted';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {
 
GetAll:QuizQuestion[]=[];
answer:QuizQuestion[]=[];
questions:QuizQuestion= new QuizQuestion();
submit:Userseleted= new Userseleted();
currentPage: number = 1;
questionsPerPage: number = 3 ;
paginatedQuestions: any[] = [];
select:any;
Timeout:Boolean=false;
isCorrect:Boolean=false;
isIncorrect:Boolean=false;
showCorrectAnswer = false;
saveButtonDisabled: boolean = true;
// question:any;
remainingTime: number = 60; 
timer: any;
currentQuestion:any;
currentQuestionIndex:any;


constructor(private QuizService:QuizService, private route:Router, private MatSnackBar:MatSnackBar){
 
}
  ngOnInit(): void { 
   this.startTimer(); 
   this.GetData();
   this.GetAllQuestion();
  }

  GetAllQuestion()
  {
    this.QuizService.GetAllAdmin().subscribe(
      (response)=>{
  this.answer=response
      },
      (err)=>{
     alert(err);
      }
    )
  }

  GetData() {
    this.QuizService.GetAllQuestion().subscribe(
      (response) => {
        this.GetAll = response;
        console.log(this.GetAll)
        this.updatePaginatedQuestions();
      },
      (err) => {
        alert(err);
      }
    );
  }
  

updatePaginatedQuestions() {
  const startIndex = (this.currentPage - 1) * this.questionsPerPage;
  this.paginatedQuestions = this.GetAll.slice(startIndex, startIndex + this.questionsPerPage);
   this.currentQuestion = this.GetAll[startIndex];
}




findAnswerByQuestionId(questionId: number) {
  this.select = this.answer.find((item) => item.id === questionId);
}

// pageChanged(event: PageEvent) {
//   this.currentPage = event.pageIndex + 1;
//   this.questionsPerPage = event.pageSize;
//   this.updatePaginatedQuestions();
// }

// nextPage() {
//   this.resetTimer();
//   this.isIncorrect = false;
//   const totalPages = Math.ceil(this.GetAll.length / this.questionsPerPage);
//   if (this.currentPage < totalPages) {
//     this.currentPage++;
//     this.updatePaginatedQuestions();
//   } 
//   else{
//     this.Timeout=true;
//     clearInterval(this.timer);
//   }
// }

nextQuestion() {
  debugger;
  this.resetTimer();
  debugger
}

getTotalPages(): number {
  return Math.ceil(this.GetAll.length / this.questionsPerPage);
}

isSaveEnabled(){
  
  return this.paginatedQuestions.some(question => question.isActive );
}
isLastPage(): boolean {
  return this.currentPage === this.getTotalPages();
}

onOptionSelected(option: any, questionId: number) {
  this.saveButtonDisabled = false;
  const question = this.paginatedQuestions.find(q => q.id === questionId);
  if (question) {
  
    this.findAnswerByQuestionId(questionId)
    this.submit.questionId= questionId;
    this.submit.selectanswer= option
    const uerid= sessionStorage.getItem("userid") as string
    const uid= JSON.parse(uerid);
  this.submit.userid=uid
    
    
  }
}




save() {
  const index = this.GetAll.findIndex(question => question.id === this.submit.questionId);
  if (index !== -1) {
    this.GetAll.splice(index, 1);
  }
  this.updatePaginatedQuestions();
 
  if(this.submit.selectanswer===this.select.correctAnswer)
  {
    this.isCorrect=true;
    this.openSnackBar('Correct Answer', 'green-snackbar')
    
  }
  else{
    this.isIncorrect=true;
    this.openSnackBar('InCorrect Answer?','.red-snackbar')
  }
//   this.QuizService.OnSubmit(this.submit).subscribe(
//     (response)=>{
  
//     },
//     (err)=>{
// alert(err);
//     }
//   )
}
startTimer() {
  
  this.timer = setInterval(() => {
    this.remainingTime--;
    if (this.remainingTime <= 0) {
      clearInterval(this.timer);
      debugger;
      if (!this.currentQuestion.isActivate) {
        const currentIndex = this.paginatedQuestions.indexOf(this.currentQuestion);
        this.paginatedQuestions.splice(currentIndex, 1);
        this.SpliceData();
      }
      this.nextQuestion();
    }
    if (this.paginatedQuestions.length === 0) {
      clearInterval(this.timer);
    }
  }, 1000);
}



handleTimerExpiration(questionIndex: number) {
  // Add your logic here when the timer for a question expires
  // You can remove the question or take any other action
  console.log(`Timer expired for question ${questionIndex + 1}`);
  this.paginatedQuestions.splice(questionIndex, 1);

  // Move to the next question
  const nextQuestionIndex = questionIndex + 1;
 
}






SpliceData()
{
  this.GetAll.splice(0, 1);
  this.updatePaginatedQuestions(); 
}


// startTimer() {
//   this.timer = setInterval(() => {
//     this.remainingTime--;
//     if (this.remainingTime <= 0) {
//       clearInterval(this.timer);
//       this.nextPage();
//     }
//   }, 1000);
// }
 

resetTimer() {
  clearInterval(this.timer);
  this.remainingTime = 60; 
  this.startTimer();
}

openSnackBar(message: string, panelClass: string) {
  this.MatSnackBar.open(message, 'Close', {
    duration: 3000,
    verticalPosition: 'bottom',
    horizontalPosition: 'center',
    panelClass: panelClass
  });
}

}


