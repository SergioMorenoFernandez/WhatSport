import { Routes } from '@angular/router';
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
