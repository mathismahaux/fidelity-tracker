import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignSponsorComponent } from './assign-sponsor.component';

describe('AssignSponsorComponent', () => {
  let component: AssignSponsorComponent;
  let fixture: ComponentFixture<AssignSponsorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssignSponsorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssignSponsorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
