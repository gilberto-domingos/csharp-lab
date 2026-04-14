import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from '../../models/Student';
import { StudentService } from '../../services/student';
@Component({
  selector: 'app-student-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCard,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  templateUrl: './student-form.html',
  styleUrl: './student-form.scss',
  standalone: true,
})
export class StudentForm implements OnInit {
  studentForm!: FormGroup;
  isSubmitting = false;
  editMode = false;
  studentId?: number;
  availableCategories: any;

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService,
    private router: Router,
    private activateRoute: ActivatedRoute
  ) {
    this.studentForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      balance: [{ value: 0, disabled: true }],
    });
  }

  onSubmit() {
    if (this.studentForm.valid) {
      const student: Student = this.studentForm.getRawValue();

      if (this.editMode && this.studentId) {
        this.studentService.update(this.studentId, student).subscribe({
          next: () => {
            this.router.navigate(['/students']);
          },
          error: (error) => {
            console.log('Error - ', error);
          },
        });
      } else {
        this.studentService.create(student).subscribe({
          next: () => {
            alert('Aluno adicionado com sucesso !');
            this.router.navigate(['/students']);
          },
          error: (error) => {
            console.log('Error - ', error);
          },
        });
      }
    }
  }

  loadStudent(id: number): void {
    this.studentService.getById(id).subscribe({
      next: (student) => {
        this.studentForm.patchValue({
          name: student.name,
          balance: student.balance,
        });
      },
      error: (error) => {
        console.log('Error - ', error);
      },
    });
  }

  ngOnInit(): void {
    const type = this.studentForm.get('type')?.value;
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.editMode = true;
      this.studentId = +id;

      this.loadStudent(this.studentId);
    }
  }

  onCancel() {
    this.router.navigate(['/students']);
  }
}
