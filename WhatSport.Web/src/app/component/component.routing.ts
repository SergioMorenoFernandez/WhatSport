import { Routes } from '@angular/router';
import { NgbdAlertBasicComponent } from './alert/alert.component';

import { ButtonsComponent } from './buttons/buttons.component';
import { MatchesComponent } from './matches/matches.component';
import { ClubsComponent } from './clubs/clubs.component';
import { FriendsComponent } from './friends/friends.component';
import { CardMatchComponent } from './card-match/card-match.component';


export const ComponentsRoutes: Routes = [
	{
		path: '',
		children: [
			{
				path: 'card',
				component: CardMatchComponent
			},
			{
				path: 'alert',
				component: NgbdAlertBasicComponent
			},
			{
				path: 'buttons',
				component: ButtonsComponent
			},
			{
				path: 'match',
				component: MatchesComponent
			},
			{
				path: 'club',
				component: ClubsComponent
			},
			{
				path: 'friends',
				component: FriendsComponent
			}
		]
	}
];
