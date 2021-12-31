import { Component, Input, OnInit } from '@angular/core';
import { MatchService } from '../../services/match/match.service';
import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';
import { Router } from '@angular/router';
import { NewScoreDialogComponent } from './new-score-dialog/new-score-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Score } from '../..//Models/Score';

export class matchScore{
team1: number=0;
team2: number=0;
}

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.scss']
})
export class ScoreComponent implements OnInit {
  @Input() matchId?:number;
  @Input() numTimes:number=0;

  scoreFinal:matchScore[]=[];
  confirmations:number=0;

  constructor(private token: TokenStorageService,
          private matchService: MatchService, 
          public router: Router, 
          public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getscores();
  }

  hasscores(): boolean {
    if(this.scoreFinal.length>0)
    {
      return true;
    }
    return false;
  }

  getscores(): void {
    if(this.matchId)
    {
      this.matchService.getScoresConfirmations(this.matchId).subscribe(
        data => {
          this.confirmations = data;

        }
      );

        this.matchService.getScores(this.matchId).subscribe(
          data => {
            if(data.length != 0)
            {
              this.scoreFinal.length = (data.length/2)-1

              for(let val of data)
              {

                let clone = this.scoreFinal[val.numberTimes-1]

                if(!clone)
                {
                  clone = new matchScore();
                }
                if(val.team==1)
                {
                  clone.team1 = val.value;
                }
                else
                {
                  clone.team2 = val.value;
                }

                this.scoreFinal[val.numberTimes-1] = clone;
              }
            }
          }
        );
    }
  }

  confirmScore(): void {
    if(this.matchId)
    {
        this.matchService.confirmScore(this.matchId).subscribe({
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
        width: '350px',
        minWidth: '200px',
        data: {matchId: this.matchId, numberTimes: this.numTimes }
      });

      dialogRef.afterClosed().subscribe((result) => {
        this.getscores();
      });
    }
  }
}