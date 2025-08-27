import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';

import { PrintJob } from '../../models/PrintJob';
import { Student } from '../../models/Student';
import { StudentService } from '../../services/student';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatIconModule, MatButtonModule],
  templateUrl: './student-list.html',
  styleUrl: './student-list.scss',
})
export class StudentList implements OnInit {
  // Usamos BehaviorSubject internamente para poder emitir novas listas
  private studentsSubject = new BehaviorSubject<Student[]>([]);
  students$: Observable<Student[]> = this.studentsSubject.asObservable();

  printJobs$: Observable<PrintJob[]> = new BehaviorSubject<PrintJob[]>([]).asObservable();
  displayedColumns: string[] = ['code', 'name', 'balance', 'purchases', 'printJobs', 'actions'];

  constructor(private studentService: StudentService, private router: Router) {}

  ngOnInit(): void {
    this.loadStudents();
    this.loadPrints();
  }

  loadStudents(): void {
    this.studentService.getAll().subscribe({
      next: (students) => this.studentsSubject.next(students),
      error: (err) => console.error('Erro ao carregar alunos:', err),
    });
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
      next: () => {
        const current = this.studentsSubject.getValue();
        const updated = current.filter((s) => s.id !== student.id);
        this.studentsSubject.next(updated);
      },
      error: (error) => console.error('Erro ao deletar aluno:', error),
    });
  }
}
