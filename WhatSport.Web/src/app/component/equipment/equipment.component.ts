import { Component, Input, OnInit } from '@angular/core';
import { MatchService } from '../../services/match/match.service';
import { TokenStorageService } from '../../services/tokenStorage/token-storage.service';
import { Equipment } from '../../Models/Equipment';
import { Router } from '@angular/router';
import { NewEquipmentDialogComponent } from './new-equipment-dialog/new-equipment-dialog.component';
import { MatDialog } from '@angular/material/dialog';

export interface DialogData {
  matchId: number;
}

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  styleUrls: ['./equipment.component.scss']
})
export class EquipmentComponent implements OnInit {
@Input() matchId?:number;
  
  equipments:Equipment[]=[];

  constructor(private token: TokenStorageService,
          private matchService: MatchService, 
          public router: Router, 
          public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getEquipments();
  }

  getEquipments(): void {
    if(this.matchId)
    {
      this.matchService.getEquipments(this.matchId)
        .subscribe(data => this.equipments = data);
    }
  }

  assignEquipment(equipmentId: number): void {
    if(this.matchId)
    {
       this.matchService.assignEquipment(this.matchId, equipmentId).subscribe({
        next: data => {
          this.getEquipments();
        }
      });
    }
  }

  unAssignEquipment(equipmentId: number): void {
    if(this.matchId)
    {
      this.matchService.unAssignEquipment(this.matchId, equipmentId).subscribe({
        next: data => {
          
          this.getEquipments();
        }
      });
    }
  }

  newEquipmentDialog(): void {
    if(this.matchId)
    {
      const dialogRef = this.dialog.open(NewEquipmentDialogComponent, {
        width: '300px',
        minWidth: '200px',
        data: {matchId: this.matchId}
      });

      dialogRef.afterClosed().subscribe((result) => {
        this.getEquipments();
      });
    }
  }
}
