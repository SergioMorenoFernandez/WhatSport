import { Component, Input, OnInit } from '@angular/core';
import { MatchService } from '../../services/match/match.service';
import { Observable } from 'rxjs';

import { Player } from '../../Models/Player';

@Component({
  selector: 'app-card-match',
  templateUrl: './card-match.component.html',
  styleUrls: ['./card-match.component.css']
})
export class CardMatchComponent implements OnInit {
  @Input() matchId: number=0;
  @Input() dateStart?: Date;
  @Input() dateEnd?: Date;

  totalConfirmation: any=0;
  players: Player[]=[];

  constructor(private matchService: MatchService) { 
  }

  ngOnInit(): void {
    this.getPlayers();
  }

  randomIntFromInterval(min: number, max: number) { // min and max included 
    return Math.floor(Math.random() * (max - min + 1) + min)
  }

  getPlayers(){

    this.matchService.getPlayers(this.matchId)
      .subscribe(data => this.players=data);
      
      let id = this.randomIntFromInterval(1,5);

      this.players.forEach(element => {
        element.image = 'assets/images/users/user' + id.toString()  + '.jpg'
        
      });
  }
  
  // const rndInt = randomIntFromInterval(1, 6)
  // console.log(rndInt)

}
