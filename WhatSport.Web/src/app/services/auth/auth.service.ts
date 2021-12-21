import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

const apiURL = environment.apiURL + '/users';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(login: string, password: string): Observable<any> {
    
    var result = this.http.post(apiURL + '/login', {
      login,
      password
    }, httpOptions);
    localStorage.setItem('currentUser', JSON.stringify(result));
    return result;
  }

  register(login: string, name: string, lastName: string, password: string): Observable<any> {
    return this.http.post(apiURL + '/register', {
      login,
      name,
      lastName,
      password
    }, httpOptions);
  }
}