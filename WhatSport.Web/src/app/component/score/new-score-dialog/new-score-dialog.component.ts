import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatchService } from '../../../services/match/match.service';
import { matchScore, ScoreComponent } from '../score.component';

export interface ScoreDialogData {
  matchId: number;
  numberTimes: number;
}

@Component({
  selector: 'app-new-score-dialog',
  templateUrl: './new-score-dialog.component.html',
  styleUrls: ['./new-score-dialog.component.scss']
})
export class NewScoreDialogComponent implements OnInit {
  errorMessage = '';
  
  isValid = true;

  scoresDialog:matchScore[]=[];

  constructor(
    private matchService: MatchService, 
    public dialogRef: MatDialogRef<ScoreComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ScoreDialogData) {
      // this.scores.length = this.data.numberTimes;
      for(let i = 0;i<data.numberTimes;i++)
      {
        this.scoresDialog.push(new matchScore())
      }
    }

  ngOnInit(): void {
    
  }
    
  onNoClick(): void {
    // this.dialogRef.close();
    console.log("cerrar");
  }

  Isvalidform():boolean
  {
      return true;
  }

  createScore()
  {
    console.log("createScore");
    if (this.Isvalidform())
    {
        this.errorMessage ="";
        let i = 1;
        for(let data of this.scoresDialog)
        {
          this.matchService.createScore(data.team1,i, 1, this.data.matchId).subscribe({
            next: data => {}
          ,error: err => {
              this.errorMessage = err.error.message;
              this.isValid = false;
            }
          });

          this.matchService.createScore(data.team2,i, 2, this.data.matchId).subscribe({
            next: data => {}
          ,error: err => {
              this.errorMessage = err.error.message;
              this.isValid = false;
            }
          });

          i++;

        }

        this.dialogRef.close();
    }
    else
    {
      this.isValid = false;
      this.errorMessage = "Description is required";
    }
  }
}
