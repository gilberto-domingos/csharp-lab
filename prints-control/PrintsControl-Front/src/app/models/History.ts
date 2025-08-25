import { Student } from './Student';

export interface History {
  id: number;
  operationType: 'purchase' | 'print';
  quantity: number;
  balanceBefore: number;
  balanceAfter: number;
  date: string;
  studentId: number;
  student?: Student;
}
