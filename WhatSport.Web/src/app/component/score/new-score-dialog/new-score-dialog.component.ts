import { Component, OnInit } from '@angular/core';

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

  constructor() { }

  ngOnInit(): void {
  }

}
