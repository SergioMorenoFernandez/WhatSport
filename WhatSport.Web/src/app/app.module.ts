import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  CommonModule, LocationStrategy,
  PathLocationStrategy
} from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

//Angular material
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { ScrollingModule}  from '@angular/cdk/scrolling';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialog, MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { FullComponent } from './layouts/full/full.component';


import { NavigationComponent } from './shared/header/navigation.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';

import { Approutes } from './app-routing.module';
import { AppComponent } from './app.component';
import { SpinnerComponent } from './shared/spinner.component';

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';


import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { ProfileComponent } from './component/profile/profile.component';

import { CardMatchComponent } from './component/card-match/card-match.component';
import { SearchMatchesComponent } from './component/search-matches/search-matches.component';
import { MatchesComponent } from './component/matches/matches.component';
import { PlayersComponent } from './component/players/players.component';
import { ClubsComponent } from './component/clubs/clubs.component';
import { MatchDetailComponent } from './component/match-detail/match-detail.component';
import { FriendsComponent } from './component/friends/friends.component';

import { EquipmentComponent } from './component/equipment/equipment.component';
import { NewEquipmentDialogComponent } from './component/equipment/new-equipment-dialog/new-equipment-dialog.component';
import { ScoreComponent } from './component/score/score.component';
import { NewScoreDialogComponent } from './component/score/new-score-dialog/new-score-dialog.component';
import { NewMatchComponent } from './component/matches/new-match/new-match.component';

import { authInterceptorProviders } from './helper/auth.interceptor';

import { AuthGuard } from './helper/AuthGuard';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelSpeed: 1,
  wheelPropagation: true,
  minScrollbarLength: 20
};

@NgModule({
  declarations: [
    AppComponent,
    SpinnerComponent,
    FullComponent,
    NavigationComponent,
    SidebarComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    CardMatchComponent,
    SearchMatchesComponent,
    MatchesComponent,
    PlayersComponent,
    ClubsComponent,
    MatchDetailComponent,
    FriendsComponent,
    EquipmentComponent,
    NewEquipmentDialogComponent,
    ScoreComponent,
    NewScoreDialogComponent,
    NewMatchComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    RouterModule.forRoot(Approutes, { useHash: false, relativeLinkResolution: 'legacy' }),
    PerfectScrollbarModule,
    MatSelectModule,
    MatCardModule,
    ScrollingModule,
    MatExpansionModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatDialogModule,
    MatFormFieldModule,
    MatDatepickerModule,
  ],
  providers: [
    
    AuthGuard,
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy
    },
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    },
    authInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
