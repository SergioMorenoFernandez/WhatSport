import { Component, OnInit } from '@angular/core';

import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {
  currentUser:any;

  constructor(public router: Router, private token: TokenStorageService,) {}

  ngOnInit(): void 
  {
    this.currentUser = this.token.getUser();
  }

  
  goToNewMatch(): void
  {
    this.router.navigate([`/component/match/new`]);
  }

}
