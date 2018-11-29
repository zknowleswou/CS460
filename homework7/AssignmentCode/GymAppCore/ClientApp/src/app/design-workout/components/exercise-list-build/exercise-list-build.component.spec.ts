import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseListBuildComponent } from './exercise-list-build.component';

describe('ExerciseListBuildComponent', () => {
  let component: ExerciseListBuildComponent;
  let fixture: ComponentFixture<ExerciseListBuildComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExerciseListBuildComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseListBuildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
