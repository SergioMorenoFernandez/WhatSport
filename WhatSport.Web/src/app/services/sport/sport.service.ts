import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Sport } from '../../Models/Sport';

const apiURL = environment.apiURL + '/sport';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class SportService {

  constructor(private http: HttpClient) { }

  getSports(): Observable<Sport[]> {
    return this.http.get<Sport[]>(apiURL , httpOptions).pipe(
      catchError(this.handleError<Sport[]>(`getSports`))
    );
  }

  getSport(id: number): Observable<Sport[]> {
    return this.http.get<Sport[]>(apiURL , httpOptions).pipe(
      catchError(this.handleError<Sport[]>(`getSports`))
    );
  }

  getSportById(id: number): Observable<Sport> {
    return this.http.get<Sport>(`${apiURL}/${id}`,httpOptions).pipe(
      tap(x => x.id ?
        console.log(`found sport with id ("${id}")`) :
        console.log(`no sport found with id ("${id}")`)),
      catchError(this.handleError<Sport>('getSportById'))
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