
import { QuizService } from './../../Service/quiz.service';
import { Component, OnInit } from '@angular/core';
import { answerclass } from 'src/app/Class/answerclass';
import { QuizQuestion } from 'src/app/Class/quiz-question';

@Component({
  selector: 'app-quiz-answer',
  templateUrl: './quiz-answer.component.html',
  styleUrls: ['./quiz-answer.component.scss']
})
export class QuizAnswerComponent implements OnInit {

  answers:QuizQuestion[]=[]
  constructor(private QuizService:QuizService){}

  ngOnInit(): void {
    this.GetALLData();
  }

  GetALLData()
  {
    this.QuizService.GetAllAnswerByQuestion().subscribe(
      (response)=>{
     this.answers= response;
     console.log(this.answers);
      }
    )
  }

}
