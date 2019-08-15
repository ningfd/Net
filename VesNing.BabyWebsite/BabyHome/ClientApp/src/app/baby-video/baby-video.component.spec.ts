import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BabyVideoComponent } from './baby-video.component';

describe('BabyVideoComponent', () => {
  let component: BabyVideoComponent;
  let fixture: ComponentFixture<BabyVideoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BabyVideoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BabyVideoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
