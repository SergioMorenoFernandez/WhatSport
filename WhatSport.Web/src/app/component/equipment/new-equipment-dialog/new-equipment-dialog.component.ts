import { error } from '@angular/compiler/src/util';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatchService } from '../../../services/match/match.service';
import { EquipmentComponent } from '../equipment.component';

export interface DialogData {
  matchId: number;
}

@Component({
  selector: 'app-new-equipment-dialog',
  templateUrl: './new-equipment-dialog.component.html',
  styleUrls: ['./new-equipment-dialog.component.scss']
})
export class NewEquipmentDialogComponent {
  description: string='';
  errorMessage = '';
  
  isValid = true;

  constructor(
    private matchService: MatchService, 
    public dialogRef: MatDialogRef<EquipmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}
    
  onNoClick(): void {
    this.dialogRef.close();
  }

  createEquipment()
  {
    if (this.description)
    {
      this.errorMessage ="";
      this.matchService.createEquipment(this.description, this.data.matchId).subscribe({
        next: data => {
        this.dialogRef.close();
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isValid = true;
      }
      });
    }
    else
    {
      this.isValid = false;
      this.errorMessage = "Description is required";
    }
  }
}
