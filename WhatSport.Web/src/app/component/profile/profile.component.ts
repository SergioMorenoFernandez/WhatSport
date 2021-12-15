import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user/user.service';

import { MatchService } from '../../services/match/match.service';
import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  currentUser: any;
  totalFriends: number=0;
  totalMatch: number=0;

  constructor(private token: TokenStorageService, private userService: UserService, private matchService: MatchService) { }

  ngOnInit(): void {
    this.currentUser = this.token.getUser();
    this.getTotalFriends();
    this.getTotalMatch();
  }


  getTotalFriends(): void {
    this.userService.getTotalFriends()
      .subscribe(data => this.totalFriends=data);
  }

  getTotalMatch(): void {
    this.matchService.getTotalMatch()
      .subscribe(data => this.totalMatch=data);
  }
}