import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BabyJournalListComponent } from './baby-journal-list.component';

describe('BabyJournalComponent', () => {
  let component: BabyJournalListComponent;
  let fixture: ComponentFixture<BabyJournalListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BabyJournalListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BabyJournalListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
