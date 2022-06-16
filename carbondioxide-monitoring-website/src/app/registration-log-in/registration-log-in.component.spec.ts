import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrationLogInComponent } from './registration-log-in.component';

describe('RegistrationLogInComponent', () => {
  let component: RegistrationLogInComponent;
  let fixture: ComponentFixture<RegistrationLogInComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistrationLogInComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationLogInComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
