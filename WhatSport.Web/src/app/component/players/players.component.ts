import { Component, Input, OnInit } from '@angular/core';
import { Player } from '../../Models/Player';

import { MatchService } from '../../services/match/match.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit {
  @Input() numPlayer: number=0;
  @Input() matchId: number=0;
  @Input() team: number=0;

  players: Player[] = [];
  
  playersTeam: Player[] = [];

  constructor(private matchService: MatchService) { }

  ngOnInit(): void {
    this.getPlayers();    
  }

  initializePlayersTeam() : void {
    this.playersTeam = [];
    this.playersTeam.length = this.numPlayer;
  }

  getPlayers(){
    this.matchService.getPlayers(this.matchId, this.team)
    .subscribe({
      next: (data) => {
        this.initializePlayersTeam();
        this.players = data
    
        let count=0;
        for(let p of this.players )
        {
          if(this.playersTeam.length > count)
          {
            this.playersTeam[count] =p;
          }
          count+=1;
        }
        // this.reloadPage();
        
      }
    });

  }

  join() : void {
    
    this.matchService.joinMatch(this.matchId, this.team)
    .subscribe({
      next: (data) => {
        this.getPlayers();
      }
    });
  }

  unjoin(userId: number) : void {
    
    this.matchService.unjoinMatch(this.matchId, userId)
    .subscribe({
      next: (data) => {
        this.getPlayers();
      }
    });
  }

}
