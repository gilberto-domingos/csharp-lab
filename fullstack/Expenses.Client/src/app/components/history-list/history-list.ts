import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { Observable, of } from 'rxjs';

import { Router } from '@angular/router';
import { PrintJob } from '../../models/PrintJob';
import { Purchase } from '../../models/Purchase';
import { Student } from '../../models/Student';
import { StudentService } from '../../services/student';

@Component({
  selector: 'app-history-list',
  imports: [CommonModule, MatCardModule, MatTableModule, MatIconModule, MatButtonModule],
  templateUrl: './history-list.html',
  styleUrl: './history-list.scss',
  standalone: true,
})
export class HistoryList {
  onDelete(_t61: any) {
    throw new Error('Method not implemented.');
  }
  onEdit(_t61: any) {
    throw new Error('Method not implemented.');
  }
  students$: Observable<Student[]> = of([]);
  printJobs$: Observable<PrintJob[]> = of([]);
  printPurchases$: Observable<Purchase[]> = of([]);

  displayedColumns: string[] = [
    'code',
    'name',
    'balance',
    'purchases',
    'datePurchase',
    'printJobs',
    'printDate',
  ];
  dataSource: any;

  constructor(private studentService: StudentService, private router: Router) {}

  loadStudents(): void {
    this.students$ = this.studentService.getAll();
  }

  loadPrints(): void {
    this.printJobs$ = this.studentService.getPrintDocuments();
  }

  loadPurchases(): void {
    this.printPurchases$ = this.studentService.getAllPurchases();
  }

  getTotalPrints(printJobs: PrintJob[] | undefined): number {
    if (!printJobs || printJobs.length === 0) return 0;
    return printJobs.reduce((total, job) => total + job.quantity, 0);
  }

  ngOnInit() {
    this.loadStudents();
    this.loadPrints();
    this.loadPurchases();

    this.students$.subscribe((students) => {
      console.log('AQUI ESTÃO OS ESTUDANTES', students);
    });

    this.printJobs$.subscribe((printJobs) => {
      console.log('IMPRIMINDO AS IMPRESSÕES', printJobs);
    });

    this.printPurchases$.subscribe((purchases) => {
      console.log('IMPRIMINDO AS COMPRAS', purchases);
    });
  }
}
