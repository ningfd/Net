import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BabyPhotoMainComponent } from './baby-photo-main.component';

describe('BabyPhotoMainComponent', () => {
  let component: BabyPhotoMainComponent;
  let fixture: ComponentFixture<BabyPhotoMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BabyPhotoMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BabyPhotoMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
