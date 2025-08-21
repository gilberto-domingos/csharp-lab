import { Routes } from '@angular/router';
import { Drafts } from './components/drafts/drafts';
import { HistoryList } from './components/history-list/history-list';
import { LoginForm } from './components/login-form/login-form';
import { PrintJobForm } from './components/print-job-form/print-job-form';
import { PurchaseForm } from './components/purchase-form/purchase-form';
import { PurchaseList } from './components/purchase-list/purchase-list';
import { Signup } from './components/signup/signup';
import { StudentForm } from './components/student-form/student-form';
import { StudentList } from './components/student-list/student-list';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginForm,
  },
  {
    path: 'drafts',
    component: Drafts,
  },
  {
    path: 'signup',
    component: Signup,
  },
  {
    path: 'purchases',
    children: [
      { path: '', component: PurchaseList },
      { path: 'add', component: PurchaseForm },
      {
        path: 'edit/:id',
        component: PurchaseForm,
        data: { renderMode: 'client' },
      },
    ],
  },
  {
    path: 'students',
    children: [
      { path: '', component: StudentList },
      { path: 'add', component: StudentForm },
      {
        path: 'edit/:id',
        component: StudentForm,
        data: { renderMode: 'client' },
      },
      {
        path: 'add/:print',
        component: PrintJobForm,
        data: { renderMode: 'client' },
      },
      { path: 'history', component: HistoryList },
    ],
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' },
];
