import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ComponentsRoutes } from './component.routing';
import { MatchesComponent } from './matches/matches.component';
import { ClubsComponent } from './clubs/clubs.component';
import { MatchDetailComponent } from './match-detail/match-detail.component';
import { FriendsComponent } from './friends/friends.component';




@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ComponentsRoutes),
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  declarations: [
    MatchesComponent,
    ClubsComponent,
    MatchDetailComponent,
    FriendsComponent
  ]
})
export class ComponentsModule { }
