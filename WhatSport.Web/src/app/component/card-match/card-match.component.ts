import { Component, Input, OnInit } from '@angular/core';
import { MatchService } from '../../services/match/match.service';
import { Observable } from 'rxjs';

import { Match } from '../../Models/Match';
import { Router } from '@angular/router';

@Component({
  selector: 'app-card-match',
  templateUrl: './card-match.component.html',
  styleUrls: ['./card-match.component.css']
})
export class CardMatchComponent implements OnInit {
  @Input() matchId: number=0;
  @Input() date?: Date;
  @Input() numPlayer: number=0;
  
  
  totalConfirmation: any=0;
  match: Match= <Match>{};

  constructor(public router: Router, private matchService: MatchService) { 
  }

  ngOnInit(): void {
    this.getmatch(this.matchId);
  }

  randomIntFromInterval(min: number, max: number) { // min and max included 
    return Math.floor(Math.random() * (max - min + 1) + min)
  }

  getmatch(matchId: number)
  {
    this.matchService.getMatchById(matchId)
    .subscribe(data => this.match=data);
  }

  goToDetail(): void
  {
    this.router.navigate([`/component/match/${this.matchId}`]);
  }
}
