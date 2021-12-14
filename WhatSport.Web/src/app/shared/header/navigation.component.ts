import { Component, AfterViewInit, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';

declare var $: any;

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html'
})
export class NavigationComponent implements AfterViewInit {
  @Output() toggleSidebar = new EventEmitter<void>();

  public config: PerfectScrollbarConfigInterface = {};

  public showSearch = false;
  
  isLoggedIn = false;
  username?: string;

  constructor(private router: Router, private tokenStorageService: TokenStorageService, private modalService: NgbModal) {
  }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.username = user?.login;
    }
  }

  ngAfterViewInit() { }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }
}
