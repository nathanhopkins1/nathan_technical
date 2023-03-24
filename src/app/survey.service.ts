import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  constructor(private http: HttpClient) { }

  submitResponse(response: any){
    return this.http.post<any>('https://localhost:7297/api/Response/submit-response', response);
  }

  getResults(){
    return this.http.get<any>('https://localhost:7297/api/Response');
  }
}
