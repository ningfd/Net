import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NgMenuComponent } from './ng-menu.component';

describe('NgMenuComponent', () => {
  let component: NgMenuComponent;
  let fixture: ComponentFixture<NgMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NgMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NgMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
