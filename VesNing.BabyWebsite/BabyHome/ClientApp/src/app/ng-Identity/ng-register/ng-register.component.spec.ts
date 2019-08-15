import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NgRegisterComponent } from './ng-register.component';

describe('NgRegisterComponent', () => {
  let component: NgRegisterComponent;
  let fixture: ComponentFixture<NgRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NgRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NgRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
