import { Component, OnInit } from '@angular/core';

import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {
  currentUser:any;

  constructor(private token: TokenStorageService,) {}

  ngOnInit(): void 
  {
    this.currentUser = this.token.getUser();
  }

}
