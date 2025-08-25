import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Purchase } from '../../models/Purchase';
import { Student } from '../../models/Student';
import { StudentService } from '../../services/student';

@Component({
  selector: 'app-purchase-form',
  templateUrl: './purchase-form.html',
  styleUrls: ['./purchase-form.scss'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    NgIf,
    NgFor,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatCard,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
})
export class PurchaseForm implements OnInit {
  editMode: any;

  purchaseForm!: FormGroup;
  students: Student[] = [];
  isEditMode = false;
  purchaseId?: number;
  quantities = [25, 50];
  isSubmitting = false;

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService,
    private route: ActivatedRoute,
    public router: Router
  ) {}
  ngOnInit(): void {
    this.purchaseForm = this.fb.group({
      studentId: ['', Validators.required],
      quantity: ['', Validators.required],
      purchaseDate: [new Date(), Validators.required],
    });

    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getAll().subscribe({
      next: (students) => (this.students = students),
      error: (err) => console.error('Erro ao carregar estudantes', err),
    });
  }

  onSubmit(): void {
    if (!this.purchaseForm.valid) return;

    const purchase: Purchase = {
      studentId: this.purchaseForm.value.studentId,
      quantity: this.purchaseForm.value.quantity,
      purchaseDate: this.purchaseForm.value.purchaseDate.toISOString(),
    };

    this.isSubmitting = true;

    this.studentService.createPurchase(purchase).subscribe({
      next: () => {
        this.isSubmitting = false;
        alert('Compra realizada com sucesso!');
        this.router.navigate(['/students']);
      },
      error: (error) => {
        this.isSubmitting = false;
        console.error('Erro ao criar compra:', error);
        if (error.error && error.error.message) {
          alert('Erro: ' + error.error.message);
        } else {
          alert('Erro inesperado ao criar a compra.');
        }
      },
    });
  }
}
