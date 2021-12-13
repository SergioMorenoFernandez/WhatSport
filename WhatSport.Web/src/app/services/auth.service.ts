import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

// const AUTH_API = '/api/users/';
const AUTH_API = 'https://localhost:57097/users';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(login: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + '/login', {
      login,
      password
    }, httpOptions);
  }

  register(username: string, email: string, password: string): Observable<any> {
    return this.http.post(AUTH_API , {
      username,
      email,
      password
    }, httpOptions);
  }
}