import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SetListBuildComponent } from './set-list-build.component';

describe('SetListBuildComponent', () => {
  let component: SetListBuildComponent;
  let fixture: ComponentFixture<SetListBuildComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SetListBuildComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SetListBuildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
