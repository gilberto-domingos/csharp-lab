import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Purchase } from '../models/Purchase';
import { Student } from '../models/Student';
import { PrintJob } from './../models/PrintJob';

// import { environment } from '../../environments/environment';
// private apiUrl = environment.apiUrl + '/Students';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  //private apiUrl = 'https://meuappapi.azurewebsites.net/api/Student';

  private apiUrl = 'https://fullstack-6-40oe.onrender.com/api/Students';

  //private apiUrl = 'http://localhost:5000/api/Students';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Student[]> {
    return this.http.get<Student[]>(this.apiUrl + '/All');
  }

  getAllPurchases(): Observable<Purchase[]> {
    return this.http.get<Purchase[]>(this.apiUrl + '/Purchases');
  }

  getById(id: number): Observable<Student> {
    return this.http.get<Student>(this.apiUrl + '/Details/' + id);
  }

  create(student: Student): Observable<Student> {
    return this.http.post<Student>(this.apiUrl + '/Create', student);
  }

  createPurchase(purchase: Purchase): Observable<Purchase> {
    return this.http.post<Purchase>(this.apiUrl + '/Purchase  ', purchase);
  }

  printDocuments(printJob: PrintJob): Observable<PrintJob> {
    return this.http.post<PrintJob>(this.apiUrl + '/print', printJob);
  }

  getPrintDocuments(): Observable<PrintJob[]> {
    return this.http.get<PrintJob[]>(this.apiUrl + '/print');
  }

  update(id: number, student: Student): Observable<Student> {
    return this.http.put<Student>(this.apiUrl + '/Update/' + id, student);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/Delete/' + id);
  }
}
