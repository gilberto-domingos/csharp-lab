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
  imports: [CommonModule, MatCardModule, MatTableModule, MatIconModule, MatButtonModule],
  templateUrl: './student-list.html',
  styleUrl: './student-list.scss',
  standalone: true,
})
export class StudentList implements OnInit {
  // private studentsSubject = new BehaviorSubject<Student[]>([]);
  //students$: Observable<Student[]> = this.studentsSubject.asObservable();

  private studentsSubject = new BehaviorSubject<Student[]>([]);
  students$ = this.studentsSubject.asObservable();

  private printJobsSubject = new BehaviorSubject<PrintJob[]>([]);
  printJobs$: Observable<PrintJob[]> = this.printJobsSubject.asObservable();

  displayedColumns: string[] = ['code', 'name', 'balance', 'purchases', 'printJobs', 'actions'];

  constructor(private studentService: StudentService, private router: Router) {}

  loadStudents(): void {
    this.studentService.getAll().subscribe({
      next: (students) => this.studentsSubject.next(students),
      error: (err) => console.error(err),
    });
  }

  loadPrints(): void {
    this.studentService.getPrintDocuments().subscribe({
      next: (prints) => this.printJobsSubject.next(prints),
      error: (err) => console.error('Erro ao carregar impressões:', err),
    });
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
      next: (res) => {
        window.location.reload();
      },
      error: (err) => {
        console.error('Erro ao deletar aluno:', err);
        alert('Erro no delete!');
      },
    });
  }

  ngOnInit() {
    this.loadStudents();
    this.loadPrints();
  }
}
