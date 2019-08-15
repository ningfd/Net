import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NgMainComponent } from './ng-main.component';

describe('NgMainComponent', () => {
  let component: NgMainComponent;
  let fixture: ComponentFixture<NgMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NgMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NgMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
