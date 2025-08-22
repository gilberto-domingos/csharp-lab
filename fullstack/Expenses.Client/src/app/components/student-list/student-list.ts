import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { Observable, of } from 'rxjs';

import { Router } from '@angular/router';
import { PrintJob } from '../../models/PrintJob';
import { Student } from '../../models/Student';
import { StudentService } from '../../services/student';

@Component({
  selector: 'app-student-list',
  imports: [CommonModule, MatCardModule, MatTableModule, MatIconModule, MatButtonModule],
  templateUrl: './student-list.html',
  styleUrl: './student-list.scss',
  standalone: true,
})
export class StudentList implements OnInit {
  students$: Observable<Student[]> = of([]);
  printJobs$: Observable<PrintJob[]> = of([]);

  displayedColumns: string[] = ['code', 'name', 'balance', 'purchases', 'printJobs', 'actions'];
  dataSource: any;

  constructor(private studentService: StudentService, private router: Router) {}

  loadStudents(): void {
    this.students$ = this.studentService.getAll();
  }

  loadPrints(): void {
    this.printJobs$ = this.studentService.getPrintDocuments();
  }

  getTotalPrints(printJobs: PrintJob[] | undefined): number {
    if (!printJobs || printJobs.length === 0) return 0;
    return printJobs.reduce((total, job) => total + job.quantity, 0);
  }

  onEdit(student: Student): void {
    if (student.id) {
      this.router.navigate(['/students/edit', student.id]);
    }
  }

  onDelete(student: Student): void {
    if (!student.id) return;

    if (student.balance > 0) {
      alert(`O aluno "${student.name}" não pode ser deletado pois possui saldo.`);
      return;
    }

    const confirmDelete = confirm(`Tem certeza que deseja apagar o aluno "${student.name}"?`);
    if (!confirmDelete) return;

    this.studentService.delete(student.id).subscribe({
      next: () => this.loadStudents(),
      error: (error) => console.error('Erro ao deletar aluno:', error),
    });
  }

  ngOnInit() {
    this.loadStudents();
    this.loadPrints();
  }
}
