import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SetDetailsBuildComponent } from './set-details-build.component';

describe('SetDetailsBuildComponent', () => {
  let component: SetDetailsBuildComponent;
  let fixture: ComponentFixture<SetDetailsBuildComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SetDetailsBuildComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SetDetailsBuildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
