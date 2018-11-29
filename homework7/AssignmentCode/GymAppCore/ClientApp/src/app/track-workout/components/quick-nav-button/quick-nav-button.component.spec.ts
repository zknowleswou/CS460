import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickNavButtonComponent } from './quick-nav-button.component';

describe('QuickNavButtonComponent', () => {
  let component: QuickNavButtonComponent;
  let fixture: ComponentFixture<QuickNavButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickNavButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickNavButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
