import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Student } from './Class/student';
import { StudentComponent } from './Component/student/student.component';
import { HomeComponent } from './Component/home/home.component';
import { LoginComponent } from './Component/login/login.component';
import { RegisterComponent } from './Component/register/register.component';
import { JwtActiveGuardService } from './Service/jwt-active-guard.service';
import { QuizComponent } from './Component/quiz/quiz.component';
import { QuizAnswerComponent } from './Component/quiz-answer/quiz-answer.component';
import { QuizQuestionComponent } from './Component/quiz-question/quiz-question.component';
import { QuizGuard } from './quiz.guard';

const routes: Routes = [
  {path:"", redirectTo:"home",pathMatch:"full"},
  {path:"home",component:HomeComponent,canActivate:[JwtActiveGuardService]},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"student",component:StudentComponent,canActivate:[JwtActiveGuardService]},
  {path:"quiz",component:QuizComponent,canActivate:[JwtActiveGuardService,QuizGuard]},
  {path:"answer", component:QuizAnswerComponent,canActivate:[JwtActiveGuardService]},
  {path:"quizquestion", component:QuizQuestionComponent,canActivate:[JwtActiveGuardService]}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
