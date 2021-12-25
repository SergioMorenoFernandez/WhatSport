import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewScoreDialogComponent } from './new-score-dialog.component';

describe('NewScoreDialogComponent', () => {
  let component: NewScoreDialogComponent;
  let fixture: ComponentFixture<NewScoreDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewScoreDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewScoreDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
