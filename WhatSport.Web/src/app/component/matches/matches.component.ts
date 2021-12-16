import { Component, OnInit } from '@angular/core';


import { MatchService } from '../../services/match/match.service';
import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';
import { Match } from '../../Models/Match';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {
  currentUser: any;

  constructor(private token: TokenStorageService,) { }

  ngOnInit(): void {
  }

}
