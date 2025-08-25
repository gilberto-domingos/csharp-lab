import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { Observable, combineLatest, map, of } from 'rxjs';

import { Router } from '@angular/router';
import { Transaction } from '../../models/transaction';
import { TransactionService } from '../../services/transactionService';

@Component({
  selector: 'app-transaction-list',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
  ],
  templateUrl: './transaction-list.html',
  styleUrl: './transaction-list.scss',
})
export class TransactionList implements OnInit {
  transactions$: Observable<Transaction[]> = of([]);

  totalIncome$!: Observable<number>;
  totalExpenses$!: Observable<number>;
  netBalance$!: Observable<number>;

  displayedColumns: string[] = [
    'createdAt',
    'type',
    'category',
    'amount',
    'actions',
  ];

  readonly TYPE_INCOME = 'income';
  readonly TYPE_EXPENSE = 'expense';

  constructor(
    private transactionService: TransactionService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadTransactions();
  }

  loadTransactions(): void {
    this.transactions$ = this.transactionService.getAll();

    this.totalIncome$ = this.transactions$.pipe(
      map((transactions) =>
        transactions
          .filter((t) => ['income', 'receita'].includes(t.type.toLowerCase()))
          .reduce((total, t) => total + t.amount, 0)
      )
    );

    this.totalExpenses$ = this.transactions$.pipe(
      map((transactions) =>
        transactions
          .filter((t) => ['expense', 'despesa'].includes(t.type.toLowerCase()))
          .reduce((total, t) => total + t.amount, 0)
      )
    );

    this.netBalance$ = combineLatest([
      this.totalIncome$,
      this.totalExpenses$,
    ]).pipe(map(([income, expenses]) => income - expenses));
  }

  getBalanceClass(balance: number): string {
    return balance <= 0 ? 'negative-balance' : 'balance';
  }

  onEdit(transaction: Transaction): void {
    if (transaction.id) {
      this.router.navigate(['/transactions/edit', transaction.id]);
    }
  }

  onDelete(transaction: Transaction): void {
    if (transaction.id) {
      confirm('Tem certeza que deseja apagar essa transação?');
      this.transactionService.delete(transaction.id).subscribe({
        next: () => {
          this.loadTransactions();
        },
        error: (error) => {
          console.log('Error - ', error);
        },
      });
    }
  }

  getRowClass(tx: Transaction): string {
    const type = tx.type?.toLowerCase().trim();
    return ['income', 'receita'].includes(type)
      ? 'income-row'
      : ['expense', 'despesa'].includes(type)
      ? 'expense-row'
      : '';
  }
}
