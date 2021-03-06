import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { environment } from '../../../environments/environment';
import { User } from '../../Models/User';
import { catchError } from 'rxjs/operators';

const apiURL = environment.apiURL + '/users';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  getUsers(): Observable<User> {
    // return this.http.get(apiURL , httpOptions);
    return this.http.get<User>(apiURL , httpOptions).pipe(
      catchError(this.handleError<User>(`getUsers`))
    );
  }

  getFriends(): Observable<any> {
    return this.http.get<User>(apiURL+ `/friend`,httpOptions).pipe(
      catchError(this.handleError<User[]>(`getFriends`))
    );
  }

  AddFriend(userFriendId: number): Observable<any> {
     return this.http.post(apiURL+ `/friend`,{userFriendId},httpOptions).pipe(
      catchError(this.handleError<User>(`AddFriend`))
    );
  }

  RemoveFriends(userFriendId: number): Observable<any> {
    return this.http.delete<User>(apiURL+ `/friend/${userFriendId}`,httpOptions).pipe(
      catchError(this.handleError<User>(`RemoveFriends`))
    );
  }

  getTotalFriends(): Observable<any> {
    return this.http.get<any>(apiURL+ `/totalfriends`,httpOptions).pipe(
      catchError(this.handleError<any>(`getTotalFriends`))
    );
  }


  
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
   private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }


}