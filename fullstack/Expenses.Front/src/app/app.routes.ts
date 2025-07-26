import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Signup } from './components/signup/signup';
import { TransactionForm } from './components/transaction-form/transaction-form';
import { TransactionList } from './components/transaction-list/transaction-list';

export const routes: Routes = [
  {
    path: 'login',
    component: Login,
  },
  {
    path: 'signup',
    component: Signup,
  },
  {
    path: 'transactions',
    component: TransactionList,
  },
  {
    path: 'add',
    component: TransactionForm,
  },
  {
    path: 'edit/:id',
    component: TransactionForm,
  },
  {
    path: '',
    redirectTo: '/transactions',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: '/transactions',
  },
];
