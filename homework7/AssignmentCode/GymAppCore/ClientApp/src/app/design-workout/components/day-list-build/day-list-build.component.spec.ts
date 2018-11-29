import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DayListBuildComponent } from './day-list-build.component';

describe('DayListBuildComponent', () => {
  let component: DayListBuildComponent;
  let fixture: ComponentFixture<DayListBuildComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DayListBuildComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DayListBuildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
