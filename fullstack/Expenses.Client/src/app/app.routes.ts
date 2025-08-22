import { Routes } from '@angular/router';
import { HistoryList } from './components/history-list/history-list';
import { LoginForm } from './components/login-form/login-form';
import { PrintJobForm } from './components/print-job-form/print-job-form';
import { PurchaseForm } from './components/purchase-form/purchase-form';
import { StudentForm } from './components/student-form/student-form';
import { StudentList } from './components/student-list/student-list';

export const routes: Routes = [
  { path: 'login', component: LoginForm },

  {
    path: 'students',
    children: [
      { path: '', component: StudentList },
      { path: 'add/purchases', component: PurchaseForm },
      { path: 'add', component: StudentForm },
      { path: 'edit/:id', component: StudentForm },
      { path: 'add/:print', component: PrintJobForm },
      { path: 'history', component: HistoryList },
    ],
  },

  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' },
];
