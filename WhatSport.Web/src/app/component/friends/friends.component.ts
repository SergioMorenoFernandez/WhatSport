import { Component, OnInit } from '@angular/core';

import { TableRows, Employee} from './table-data';

import { UserService } from '../../services/user/user.service';
import { User } from '../../Models/User';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit {
  
  errorMessage = '';
  topFriends:User[]=[];

  trow:TableRows[];

  
  constructor(private userService: UserService) { 
    this.trow=Employee;
  }

  ngOnInit(): void {
    this.getFriends();
  }

  getFriends(): void {
    this.userService.getFriends()
      .subscribe(data => this.topFriends=data);
  }


}

