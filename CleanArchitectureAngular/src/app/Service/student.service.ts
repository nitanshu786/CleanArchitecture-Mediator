import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../Class/student';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private HttpClient: HttpClient) { }

  GetAllStudentService():Observable<any>
  {
    debugger
    return this.HttpClient.get<any>("https://localhost:44339/api/StudentAPI");
  }

  CreateStudentService(newS:Student):Observable<any>
  {
    debugger
    return this.HttpClient.post<any>("https://localhost:44339/api/StudentAPI",newS);
  }
  UpdateStudentService(upd:Student):Observable<Student>
  {
    return this. HttpClient.put<Student>("https://localhost:44339/api/StudentAPI",upd);
  }
  DeleteStudentService(id:any):Observable<any>
  {
    return this.HttpClient.delete<any>("https://localhost:44339/api/StudentAPI/"+id);
  }

 
}
