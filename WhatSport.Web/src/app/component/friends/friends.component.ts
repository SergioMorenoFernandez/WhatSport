import { Component, OnInit } from '@angular/core';

import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';
import { UserService } from '../../services/user/user.service';
import { User } from '../../Models/User';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit {
  currentUser: any;
  errorMessage = '';
  topFriends:User[]=[];
  
  constructor(private token: TokenStorageService,private userService: UserService) { 
    this.currentUser = this.token.getUser();
  }

  ngOnInit(): void {
    this.getFriends();
  }

  getFriends(): void {
    this.userService.getFriends()
      .subscribe(data => this.topFriends=data);
  }


}

