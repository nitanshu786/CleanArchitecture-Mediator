import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Component/home/home.component';
import { LoginComponent } from './Component/login/login.component';
import { StudentComponent } from './Component/student/student.component';
import { RegisterComponent } from './Component/register/register.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import {  HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatRadioModule } from '@angular/material/radio';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AnalyticsComponent } from './Component/analytics/analytics.component';
import { JwtInterceptor, JwtModule } from '@auth0/angular-jwt';
import { IntersepterService } from './Service/intersepter.service';
import { TimingIntercepterService } from './Service/timing-intercepter.service';
import { OrderByPipe } from './Pipes/order-by.pipe';
import { SortedPipe } from './Pipes/sorted.pipe';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    StudentComponent,
    RegisterComponent,
    AnalyticsComponent,
    OrderByPipe,
    SortedPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
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
          debugger
return sessionStorage.getItem("CurrentUsers")? JSON.parse(sessionStorage.getItem("CurrentUsers") as string).token:null
        }
      }
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TimingIntercepterService,
      multi: true
    },
    {
      provide:HTTP_INTERCEPTORS,
      useClass:IntersepterService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
