import { Component, Inject, OnInit } from '@angular/core';
import { Match } from '../../../Models/Match';
import { MatchService } from '../../../services/match/match.service';
import { Router } from '@angular/router';
import { Sport } from '../../../Models/Sport';
import { FormControl, Validators } from '@angular/forms';
import { SportService } from '../../../services/sport/sport.service';
import { ElementSchemaRegistry } from '@angular/compiler';

@Component({
  selector: 'app-new-match',
  templateUrl: './new-match.component.html',
  styleUrls: ['./new-match.component.scss']
})
export class NewMatchComponent  implements OnInit  {

  description: string='';
  errorMessage = '';
  match: Match=<Match>{};
  selectedSport:Sport=<Sport>{};

  lista:Sport[]=[];
  
  sportControl = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);
  
  isValid = false;

  constructor(public router: Router, private matchService: MatchService, private sportService: SportService) {}
    
  
  ngOnInit(): void {
  
    this.getSports();

  }

  
  getSports(): void {
    this.sportService.getSports()
      .subscribe(data => this.lista = data);
  }

  onNoClick(): void {
    
  }

  createMatch()
  {
      this.errorMessage ="";
      this.match.sportId= this.sportControl.value.id;
      this.matchService.createMatch(this.match.dateStart, this.match.timeInMinutes, this.match.sportId, this.match.otherPlace, this.match.note).subscribe({
        next: data => {
          this.goToDetail(data);

      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isValid = false;
      }
      });
  }

  goToDetail(matchId:number): void
  {
    this.router.navigate([`/component/match/${matchId}`]);
  }
}
