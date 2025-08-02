import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-drafts',
  imports: [MatButtonModule, MatIconModule, MatToolbarModule],
  templateUrl: './drafts.html',
  styleUrl: './drafts.scss',
})
export class Drafts {}

// clean form
// onCancel() {
//   this.transactionForm.reset({
//     type: 'Expense',
//     category: null,
//     amount: 0,
//     createdAt: new Date(),
//   });

//   this.transactionForm.markAsPristine();
//   this.transactionForm.markAsUntouched();
// }
