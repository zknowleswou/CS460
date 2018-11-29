import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewSetDialogComponent } from './new-set-dialog.component';

describe('NewSetDialogComponent', () => {
  let component: NewSetDialogComponent;
  let fixture: ComponentFixture<NewSetDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewSetDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewSetDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
