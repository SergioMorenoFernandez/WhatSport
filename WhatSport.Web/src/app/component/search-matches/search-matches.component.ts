import { Component, Input, OnInit } from '@angular/core';
import { Match } from '../../Models/Match';
import { Sport } from '../../Models/Sport';
import { MatchService } from '../../services/match/match.service';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { SportService } from '../../services/sport/sport.service';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-search-matches',
  templateUrl: './search-matches.component.html',
  styleUrls: ['./search-matches.component.css']
})
export class SearchMatchesComponent  implements OnInit {
  @Input() userId: number=0;

  animalControl = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);
  
  matches$!: Observable<Match[]>;
  
  lista:Sport[]=[];

  private searchTerms = new Subject<Sport>();

  constructor(private matchService: MatchService, private sportService: SportService ) {}

  // Push a search term into the observable stream.
  search(term: Sport): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
  
    this.getSports();

    this.matches$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((sport: Sport) =>
           this.userId !=0
           ? this.matchService.searchBySportAndUser(sport.id,this.userId)
           : this.matchService.searchBySport(sport.id)),
    );
  }

  
  getSports(): void {
    this.sportService.getSports()
      .subscribe(data => this.lista=data);
  }

}