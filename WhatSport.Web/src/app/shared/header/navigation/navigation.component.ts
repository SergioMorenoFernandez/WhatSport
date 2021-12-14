import { AfterViewInit, Component, EventEmitter, Output } from '@angular/core';
import { TokenStorageService } from '../../../services/token-storage.service';

import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent  implements AfterViewInit {
  @Output() toggleSidebar = new EventEmitter<void>();

  public config: PerfectScrollbarConfigInterface = {};

  public showSearch = false;

  title = 'WhatSport.Web';
  private role: string = "";
  isLoggedIn = false;
  showAdminBoard = false;
  username?: string;

  constructor(private tokenStorageService: TokenStorageService,private modalService: NgbModal) { }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.role = user.role;

      this.showAdminBoard = this.role==='Admin';

      this.username = user.login;
    }
  }

  ngAfterViewInit() { }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }
}