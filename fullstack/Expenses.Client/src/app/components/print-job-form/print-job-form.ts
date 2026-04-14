import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router } from '@angular/router';
import { PrintJob } from '../../models/PrintJob';
import { Student } from '../../models/Student';
import { StudentService } from './../../services/student';

@Component({
  selector: 'app-print-job-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCard,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  templateUrl: './print-job-form.html',
  styleUrl: './print-job-form.scss',
  standalone: true,
})
export class PrintJobForm implements OnInit {
  printJobForm!: FormGroup;
  students: Student[] = [];
  printDocuments: PrintJob[] = [];
  isSubmitting = false;
  editMode = false;
  printJobId?: number;
  studentId?: number;

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService,
    private router: Router,
    private activateRoute: ActivatedRoute
  ) {
    this.printJobForm = this.fb.group({
      studentId: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
    });
  }

  loadStudents(): void {
    this.studentService.getAll().subscribe({
      next: (students) => (this.students = students),
      error: (err) => console.error('Erro ao carregar estudantes', err),
    });
  }

  onSubmit() {
    if (this.printJobForm.valid) {
      const printJob: PrintJob = this.printJobForm.getRawValue();

      const selectedStudent = this.students.find((s) => s.id === printJob.studentId);

      if (selectedStudent && selectedStudent.balance < printJob.quantity) {
        alert('Saldo insuficiente! Faça uma nova compra.');
        return;
      }

      this.studentService.printDocuments(printJob).subscribe({
        next: () => {
          alert('Impressão realizada com sucesso !');
          this.router.navigate(['/students']);
        },
        error: (error) => {
          if (error.status === 400) {
            alert('Saldo insuficiente ! Faça uma nova compra.');
          } else {
            console.log('Erro ao registrar impressão: ', error);
          }
        },
      });
    }
  }

  onCancel() {
    this.router.navigate(['/students']);
  }

  ngOnInit(): void {
    this.loadStudents();
  }
}
