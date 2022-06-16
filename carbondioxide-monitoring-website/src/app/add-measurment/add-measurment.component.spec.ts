import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMeasurmentComponent } from './add-measurment.component';

describe('AddMeasurmentComponent', () => {
  let component: AddMeasurmentComponent;
  let fixture: ComponentFixture<AddMeasurmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddMeasurmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddMeasurmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
