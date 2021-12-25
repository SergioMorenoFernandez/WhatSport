import { Component, Input, OnInit } from '@angular/core';
import { MatchService } from '../../services/match/match.service';
import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';
import { Router } from '@angular/router';
import { NewScoreDialogComponent } from './new-score-dialog/new-score-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Score } from '../..//Models/Score';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.scss']
})
export class ScoreComponent implements OnInit {
  @Input() matchId?:number;
  @Input() numTimes:number=0;
  
  scores:Score[]=[];

  constructor(private token: TokenStorageService,
          private matchService: MatchService, 
          public router: Router, 
          public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getscores();
  }

  getscores(): void {
    if(this.matchId)
    {
      this.matchService.getScores(this.matchId)
        .subscribe(data => this.scores = data);
    }
  }

  confirmScore(scoreId: number): void {
    if(this.matchId)
    {
        this.matchService.confirmScore(this.matchId, scoreId).subscribe({
        next: () => {
          this.getscores();
        }
      });
    }
  }

  newScoreDialog(): void {
    if(this.matchId)
    {
      const dialogRef = this.dialog.open(NewScoreDialogComponent, {
        width: '300px',
        minWidth: '200px',
        data: {matchId: this.matchId, numTimes: this.numTimes }
      });

      dialogRef.afterClosed().subscribe((result) => {
        this.getscores();
      });
    }
  }
}