import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { Transaction } from '../../models/transaction';
import { TransactionService } from '../../services/transactionService';

@Component({
  selector: 'app-transaction-list',
  imports: [
    MatCardModule,
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
  ],
  templateUrl: './transaction-list.html',
  styleUrl: './transaction-list.scss',
  standalone: true,
})
export class TransactionList implements OnInit {
  transactions: Transaction[] = [];
  displayedColumns: string[] = [
    'createdAt',
    'type',
    'category',
    'amount',
    'actions',
  ];

  row: any;

  constructor(private transactionService: TransactionService) {}

  totalIncome = 0;
  totalExpenses = 0;
  netBalance = 0;

  ngOnInit(): void {
    this.loadTransactions();
  }

  loadTransactions(): void {
    this.transactionService.getAll().subscribe((data) => {
      this.transactions = data;
    });
  }

  onEdit(transaction: Transaction) {
    console.log('Edit:', transaction);
    // navegar para tela de edição ou abrir modal
  }

  onDelete(transaction: Transaction) {
    console.log('Delete:', transaction);
    // chamar service.delete() se desejar
  }

  getRowClass(tx: Transaction): string {
    // console.log('Tipo:', tx.type);

    const type = tx.type?.toLowerCase().trim();

    return type === 'receita'
      ? 'income-row'
      : type === 'despesa'
      ? 'expense-row'
      : '';
  }
}
