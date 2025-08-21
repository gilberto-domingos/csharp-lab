import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintJobForm } from './print-job-form';

describe('PrintJobForm', () => {
  let component: PrintJobForm;
  let fixture: ComponentFixture<PrintJobForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrintJobForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintJobForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
