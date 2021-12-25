import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewEquipmentDialogComponent } from './new-equipment-dialog.component';

describe('NewEquipmentDialogComponent', () => {
  let component: NewEquipmentDialogComponent;
  let fixture: ComponentFixture<NewEquipmentDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewEquipmentDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewEquipmentDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
