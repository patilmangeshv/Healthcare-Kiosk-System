import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeKioskComponent } from './home-kiosk.component';

describe('HomeKioskComponent', () => {
  let component: HomeKioskComponent;
  let fixture: ComponentFixture<HomeKioskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeKioskComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeKioskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
