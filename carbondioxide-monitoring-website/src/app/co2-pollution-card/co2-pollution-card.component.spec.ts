import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Co2PollutionCardComponent } from './co2-pollution-card.component';

describe('Co2PollutionCardComponent', () => {
  let component: Co2PollutionCardComponent;
  let fixture: ComponentFixture<Co2PollutionCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Co2PollutionCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Co2PollutionCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
