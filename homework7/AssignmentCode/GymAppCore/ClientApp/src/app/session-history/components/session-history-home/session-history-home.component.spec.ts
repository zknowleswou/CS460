import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionHistoryHomeComponent } from './session-history-home.component';

describe('SessionHistoryHomeComponent', () => {
  let component: SessionHistoryHomeComponent;
  let fixture: ComponentFixture<SessionHistoryHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SessionHistoryHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SessionHistoryHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
