import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";


import { MatchService } from '../../services/match/match.service';
import { SportService } from '../../services/sport/sport.service';
import { Match } from '../../Models/Match';
import { Sport } from '../../Models/Sport';
import { mergeMap } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-match-detail',
  templateUrl: './match-detail.component.html',
  styleUrls: ['./match-detail.component.scss']
})
export class MatchDetailComponent implements OnInit {
  id?: string;
  errorMessage = '';

  sport?: Sport;
  match: Match = <Match>{};


  constructor(private route: ActivatedRoute,private matchService: MatchService, private sportService: SportService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get("id")??'';

    this.matchService.getMatchById(Number(this.id))
    .pipe(
      mergeMap((data: Match) => this.getSport(data))
    ).subscribe(data => {
      this.sport = data;
    });
  }

  getSport(match: Match): Observable<Sport> {
    this.match = match;
    
    return this.sportService.getSportById(this.match.sportId)
  }

}
