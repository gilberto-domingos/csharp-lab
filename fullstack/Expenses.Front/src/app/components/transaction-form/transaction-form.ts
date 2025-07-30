import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
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

@Component({
  selector: 'app-transaction-form',
  standalone: true,
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
  templateUrl: './transaction-form.html',
  styleUrl: './transaction-form.scss',
})
export class TransactionForm implements OnInit {
  onTypeChange() {
    throw new Error('Method not implemented.');
  }
  panelColor = new FormControl('red');

  transactionForm!: FormGroup;

  types = ['Despesa', 'Receita'];

  incomeCategories = ['Salário', 'Freelancer', 'Investimento'];
  expenseCategories = ['Alimentação', 'Transporte', 'Entretenimento'];

  availableCategories: string[] = [];

  constructor(private fb: FormBuilder) {
    this.transactionForm = this.fb.group({
      type: ['Expense', Validators.required],
      category: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(0)]],
      createdAt: [new Date(), Validators.required],
    });

    this.setAvailableCategories();

    this.transactionForm.get('type')?.valueChanges.subscribe(() => {
      this.setAvailableCategories();
      this.transactionForm.get('category')?.setValue('');
    });
  }

  setAvailableCategories() {
    const selectedType = this.transactionForm.get('type')?.value;
    this.availableCategories =
      selectedType === 'Income'
        ? this.incomeCategories
        : this.expenseCategories;
  }

  onCancel() {
    this.transactionForm.reset({
      type: 'Expense',
      category: null,
      amount: 0,
      createdAt: new Date(),
    });
  }

  onSubmit() {
    if (this.transactionForm.valid) {
      console.log('Transaction:', this.transactionForm.value);
      // Chame seu serviço aqui
    }
  }

  ngOnInit(): void {
    const type = this.transactionForm.get('type')?.value;
    this.availableCategories =
      type === 'Expense' ? this.expenseCategories : this.incomeCategories;
    this.transactionForm.patchValue({ category: '' });
  }
}
