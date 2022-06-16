import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserMeasurmentsComponent } from './user-measurments.component';

describe('UserMeasurmentsComponent', () => {
  let component: UserMeasurmentsComponent;
  let fixture: ComponentFixture<UserMeasurmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserMeasurmentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserMeasurmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
