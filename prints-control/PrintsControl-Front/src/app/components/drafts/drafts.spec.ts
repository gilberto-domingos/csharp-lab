import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Drafts } from './drafts';

describe('Drafts', () => {
  let component: Drafts;
  let fixture: ComponentFixture<Drafts>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Drafts]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Drafts);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
