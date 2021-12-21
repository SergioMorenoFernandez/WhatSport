import { Component, Input, OnInit } from '@angular/core';
import { Match } from '../../Models/Match';
import { Sport } from '../../Models/Sport';
import { MatchService } from '../../services/match/match.service';
import { SportService } from '../../services/sport/sport.service';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-search-matches',
  templateUrl: './search-matches.component.html',
  styleUrls: ['./search-matches.component.css']
})
export class SearchMatchesComponent  implements OnInit {
  @Input() userId?: number;

  sportControl = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);

  selectedSport:Sport=<Sport>{};
  
  matches: Match[]=[];
  
  lista:Sport[]=[];

  constructor(private matchService: MatchService, private sportService: SportService ) {}

  search(): void {

    if(this.sportControl.value )
    {
      this.matchService.GetMatches(this.sportControl.value.id, this.userId).subscribe(data => this.matches=data)
    }
  }

  ngOnInit(): void {
  
    this.getSports();

  }

  getSports(): void {
    this.sportService.getSports()
      .subscribe(data => this.lista=data);
  }

}