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
import { Router } from '@angular/router';
import { TransactionService } from '../../services/transactionService';

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
  panelColor = new FormControl('red');

  transactionForm!: FormGroup;

  types = [
    { label: 'Receita', value: 'Income' },
    { label: 'Despesa', value: 'Expense' },
  ];

  incomeCategories = ['Salário', 'Freelancer', 'Investimento'];
  expenseCategories = ['Alimentação', 'Transporte', 'Entretenimento'];

  availableCategories: string[] = [];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private transactionService: TransactionService
  ) {
    this.transactionForm = this.fb.group({
      type: ['', Validators.required],
      category: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(0)]],
      createdAt: [{ value: new Date(), disabled: true }, Validators.required],
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
    this.router.navigate(['/transactions']);
  }

  onTypeChange() {
    this.updateAvailableCategories();
  }

  updateAvailableCategories() {
    const type = this.transactionForm.get('type')?.value;
    this.availableCategories =
      type === 'Expense' ? this.expenseCategories : this.incomeCategories;
  }

  onSubmit() {
    if (this.transactionForm.valid) {
      const transaction = this.transactionForm.getRawValue();
      this.transactionService.create(transaction).subscribe((data) => {
        this.router.navigate(['/transactions']);
      });
    }
  }

  ngOnInit(): void {
    this.updateAvailableCategories();
    this.transactionForm.patchValue({ category: '' });
  }
}
