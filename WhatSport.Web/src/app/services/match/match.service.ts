import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Match } from '../../Models/Match';
import { Player } from '../../Models/Player';

import { environment } from '../../../environments/environment';
import { ErrorHandlingService } from '../errorHandling/errorHandling.service';
import { Equipment } from '../../Models/Equipment';
import { Score } from '../../Models/Score';

const apiURL = environment.apiURL + '/match';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  

  constructor(
    private http: HttpClient,
    private errorHandlingService: ErrorHandlingService) { }

  /* GET heroes whose name contains search term */
  // searchBySportAndUser(sportid: number, userid?: number): Observable<Match[]> {
    GetMatches(sportid: number, userid?: number): Observable<Match[]> {
    if (sportid==undefined || sportid==0) {
      // if not search term, return empty hero array.
      return of([]);
    }
    let query=`SportId=${sportid}`;

    if(userid != null )
    {
      query += `&UserId=${userid}`;
    }

    // return this.http.get<Match[]>(`${apiURL}/?SportId=${sportid}&UserId=${userid}`,httpOptions).pipe(
      return this.http.get<Match[]>(`${apiURL}/?${query}`,httpOptions).pipe(
      tap(x => x.length ?
        console.log(`found matches with params ("${sportid},${userid}")`) :
        console.log(`no match founf with params ("${sportid},${userid}")`)),
      catchError(this.handleError<Match[]>('searchBySportAndUser', []))
    );
  }

  getMatchById(id: number): Observable<Match> {
    return this.http.get<Match>(`${apiURL}/${id}`,httpOptions).pipe(
      tap(x => x.id ?
        console.log(`found matches with id ("${id}")`) :
        console.log(`no match founf with id ("${id}")`)),
      catchError(this.handleError<Match>('getMatchById'))
    );
  }

  getTotalMatch(): Observable<any> {
    return this.http.get<any>(apiURL+ '/totalmatch',httpOptions).pipe(
      catchError(this.handleError<any>(`getTotalMatch`))
    );
  }

  getPlayers(matchId: number, team: number): Observable<Player[]> {

    return this.http.get<Player[]>(`${apiURL}/${matchId}/team/${team}`,httpOptions).pipe(
      tap(x => x.length ?
        console.log(`found players with params ("${matchId},${team}")`) :
        console.log(`no players found with params ("${matchId},${team}")`)),
      catchError(this.handleError<Player[]>('getPlayers', []))
    );
  }

  createMatch(dateStart: Date, timeInMinutes:number, sportId: number, otherplace: string, note: string ):  Observable<any> {
    
    return this.http.post(`${apiURL}`,{dateStart, timeInMinutes, sportId, otherplace, note }, httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('createMatch', []))
    );
  }

  getEquipments(matchId: number): Observable<Equipment[]> {

    return this.http.get<Equipment[]>(`${apiURL}/${matchId}/equipment`,httpOptions).pipe(
      tap(x => x.length ?
        console.log(`found equipment with params ("${matchId}")`) :
        console.log(`no equipment found with params ("${matchId}")`)),
      catchError(this.handleError<Equipment[]>('getEquipments', []))
    );
  }

  createEquipment(description: string, matchId: number):  Observable<any> {
    return this.http.post(`${apiURL}/${matchId}/equipment/`,{description} , httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('createEquipment', []))
    );
  }

  assignEquipment(matchId: number, equipmentId: number):  Observable<any> {
    return this.http.put(`${apiURL}/${matchId}/equipment/${equipmentId}/assign`, httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('assignEquipment', []))
    );
  }

  unAssignEquipment(matchId: number, equipmentId: number):  Observable<any> {
    return this.http.put(`${apiURL}/${matchId}/equipment/${equipmentId}/unassign`, httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('unAssignEquipment', []))
    );
  }

  joinMatch(matchId: number, team: number):  Observable<any> {
    return this.http.post(`${apiURL}/${matchId}/join/${team}`, httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('JoinMatch', []))
    );
  }
    
  unjoinMatch(matchId: number, userId: number):  Observable<any> {
    return this.http.delete(`${apiURL}/${matchId}/unjoin/${userId}`,httpOptions).pipe(
      catchError(this.handleError<any>('unjoinMatch', []))
    );
  }

  getScores(matchId: number): Observable<Score[]> {

    return this.http.get<Score[]>(`${apiURL}/${matchId}/score`,httpOptions).pipe(
      tap(x => x.length ?
        console.log(`found score with params ("${matchId}")`) :
        console.log(`no score found with params ("${matchId}")`)),
      catchError(this.handleError<Score[]>('getScores', []))
    );
  }

  createScore(value: number, number: number, team:number, matchId: number):  Observable<any> {
    return this.http.post(`${apiURL}/${matchId}/score`,{value,number,team} , httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('createEquipment', []))
    );
  }

  confirmScore(matchId: number):  Observable<any> {
    return this.http.put(`${apiURL}/${matchId}/score/confirm`, httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('confirmScore', []))
    )};

    
  getScoresConfirmations(matchId: number): Observable<number> {

    return this.http.get<number>(`${apiURL}/${matchId}/score/confirm`,httpOptions).pipe(
      catchError(this.errorHandlingService.handleError<any>('getScoresConfirmations', []))
    )};
  

  
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