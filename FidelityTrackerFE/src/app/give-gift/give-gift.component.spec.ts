import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiveGiftComponent } from './give-gift.component';

describe('GiveGiftComponent', () => {
  let component: GiveGiftComponent;
  let fixture: ComponentFixture<GiveGiftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GiveGiftComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GiveGiftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
