import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BabyPhotoHandlerComponent } from './baby-photo-handler.component';

describe('BabyPhotoHandlerComponent', () => {
  let component: BabyPhotoHandlerComponent;
  let fixture: ComponentFixture<BabyPhotoHandlerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BabyPhotoHandlerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BabyPhotoHandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
