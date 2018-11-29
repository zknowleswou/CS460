import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewDayDialogComponent } from './new-day-dialog.component';

describe('NewDayDialogComponent', () => {
  let component: NewDayDialogComponent;
  let fixture: ComponentFixture<NewDayDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewDayDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewDayDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
