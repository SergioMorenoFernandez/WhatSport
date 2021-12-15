import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Match } from '../../Models/Match';

import { environment } from '../../../environments/environment';

const apiURL = environment.apiURL + '/match';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  constructor(
    private http: HttpClient) { }

  /* GET heroes whose name contains search term */
  searchBySport(term: string): Observable<Match[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<Match[]>(`${apiURL}/?name=${term}`,httpOptions).pipe(
      tap(x => x.length ?
        console.log(`found matches with params ("${term}")`) :
        console.log(`no match founf with params ("${term}")`)),
      catchError(this.handleError<Match[]>('searchHeroes', []))
    );
  }

  searchByClub(term: string): Observable<Match[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<Match[]>(`${apiURL}/?name=${term}`,httpOptions).pipe(
      tap(x => x.length ?
        console.log(`found matches with params ("${term}")`) :
        console.log(`no match founf with params ("${term}")`)),
      catchError(this.handleError<Match[]>('searchHeroes', []))
    );
  }

  searchByUser(term: string): Observable<Match[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<Match[]>(`${apiURL}/?name=${term}`,httpOptions).pipe(
      tap(x => x.length ?
        console.log(`found matches with params ("${term}")`) :
        console.log(`no match founf with params ("${term}")`)),
      catchError(this.handleError<Match[]>('searchHeroes', []))
    );
  }

  getTotalMatch(): Observable<any> {
    return this.http.get<any>(apiURL+ '/totalmatch',httpOptions).pipe(
      catchError(this.handleError<any>(`getTotalMatch`))
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