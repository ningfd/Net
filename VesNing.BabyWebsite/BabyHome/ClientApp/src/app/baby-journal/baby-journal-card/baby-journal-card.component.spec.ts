import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BabyJournalCardComponent } from './baby-journal-card.component';

describe('BabyJournalCardComponent', () => {
  let component: BabyJournalCardComponent;
  let fixture: ComponentFixture<BabyJournalCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BabyJournalCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BabyJournalCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
