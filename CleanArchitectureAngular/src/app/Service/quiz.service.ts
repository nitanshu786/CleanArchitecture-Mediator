import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Userseleted } from '../Class/userseleted';
import { answerclass } from '../Class/answerclass';
import { QuizQuestion } from '../Class/quiz-question';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private HttpClient:HttpClient, private routes:Router) { }

  GetAllQuestion():Observable<any>{
    return this.HttpClient.get("https://localhost:44339/api/Quiz/GetQuestion");
  }

  GetAllAnswerByQuestion():Observable<any>
  {
    return this.HttpClient.get<QuizQuestion>("https://localhost:44339/api/Quiz/GetAnswer");
  }

  OnSubmit(data:Userseleted):Observable<Userseleted>{
    debugger
    return this.HttpClient.post<Userseleted>("https://localhost:44339/api/Quiz",data);
  }

  GetAllAdmin():Observable<any>
  {
    return this.HttpClient.get("https://localhost:44339/api/Quiz/GetAnswer");
  }

  CreateQuestion(newone:any):Observable<QuizQuestion>
  {
    return this.HttpClient.post<QuizQuestion>("https://localhost:44339/api/Quiz/question",newone);
  }

  UpdateQuestion(newone:any):Observable<QuizQuestion>
  {
    return this.HttpClient.put<QuizQuestion>("https://localhost:44339/api/Quiz",newone);
  }

  DeleteQuestion(id:any):Observable<any>
  {
    return this.HttpClient.delete<any>("https://localhost:44339/api/Quiz/"+id);
  }

  

}
