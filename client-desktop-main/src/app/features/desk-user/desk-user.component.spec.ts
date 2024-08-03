import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeskUserComponent } from './desk-user.component';

describe('DeskUserComponent', () => {
  let component: DeskUserComponent;
  let fixture: ComponentFixture<DeskUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeskUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeskUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
