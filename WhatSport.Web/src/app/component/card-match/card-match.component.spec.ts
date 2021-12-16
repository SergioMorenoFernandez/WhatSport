import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardMatchComponent } from './card-match.component';

describe('CardMatchComponent', () => {
  let component: CardMatchComponent;
  let fixture: ComponentFixture<CardMatchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardMatchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CardMatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
