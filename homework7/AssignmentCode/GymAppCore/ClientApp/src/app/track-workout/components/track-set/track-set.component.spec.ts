import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrackSetComponent } from './track-set.component';

describe('TrackSetComponent', () => {
  let component: TrackSetComponent;
  let fixture: ComponentFixture<TrackSetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrackSetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrackSetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
