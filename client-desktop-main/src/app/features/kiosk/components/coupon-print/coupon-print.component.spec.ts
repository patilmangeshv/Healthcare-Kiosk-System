import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CouponPrintComponent } from './coupon-print.component';

describe('CouponPrintComponent', () => {
  let component: CouponPrintComponent;
  let fixture: ComponentFixture<CouponPrintComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CouponPrintComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CouponPrintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
