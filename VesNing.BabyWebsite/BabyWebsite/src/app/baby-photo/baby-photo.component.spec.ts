import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BabyPhotoComponent } from './baby-photo.component';

describe('BabyPhotoComponent', () => {
  let component: BabyPhotoComponent;
  let fixture: ComponentFixture<BabyPhotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BabyPhotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BabyPhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
