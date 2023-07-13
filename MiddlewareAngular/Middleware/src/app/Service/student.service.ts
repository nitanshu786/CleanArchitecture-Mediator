import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../Class/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private Http:HttpClient) { }

  GetAllStudent():Observable<any>
  {
    return this.Http.get<any>("https://localhost:7247/api/StudentAPI");
  }
  PostStudent(newstudent:any):Observable<any>
  {
    return this.Http.post<any>("https://localhost:7247/api/StudentAPI",newstudent);
  }
}
