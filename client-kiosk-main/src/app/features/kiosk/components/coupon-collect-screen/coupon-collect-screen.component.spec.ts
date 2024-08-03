import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CouponCollectScreenComponent } from './coupon-collect-screen.component';

describe('CouponCollectScreenComponent', () => {
  let component: CouponCollectScreenComponent;
  let fixture: ComponentFixture<CouponCollectScreenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CouponCollectScreenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CouponCollectScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
