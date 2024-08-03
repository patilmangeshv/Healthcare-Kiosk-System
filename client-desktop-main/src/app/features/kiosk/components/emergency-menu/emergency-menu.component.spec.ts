import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmergencyMenuComponent } from './emergency-menu.component';

describe('EmergencyMenuComponent', () => {
  let component: EmergencyMenuComponent;
  let fixture: ComponentFixture<EmergencyMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmergencyMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmergencyMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
