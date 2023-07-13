import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './Component/register/register.component';
import { StudentComponent } from './Component/student/student.component';
import { LoginComponent } from './Component/login/login.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import {  HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './Component/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { JwtInterceptor, JwtModule } from '@auth0/angular-jwt';
import { IntersepterService } from './Service/intersepter.service';
import { QuizComponent } from './Component/quiz/quiz.component';
import { MatRadioModule } from '@angular/material/radio';
import { MatPaginatorModule } from '@angular/material/paginator';
import { QuizAnswerComponent } from './Component/quiz-answer/quiz-answer.component';
import { QuizQuestionComponent } from './Component/quiz-question/quiz-question.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { QuizGuard } from './quiz.guard';
import { GuardsCheckStart } from '@angular/router';




@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    StudentComponent,
    LoginComponent,
    HomeComponent,
    QuizComponent,
    QuizAnswerComponent,
    QuizQuestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule,
    MatSnackBarModule,
    MatRadioModule,
    MatCardModule,
    MatPaginatorModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:()=>{
return sessionStorage.getItem("CurrentUser")? JSON.parse(sessionStorage.getItem("CurrentUser") as string).token:null
        }
      }
    }),

  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:IntersepterService,
      multi:true
    },
      
   QuizGuard
      
    
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
