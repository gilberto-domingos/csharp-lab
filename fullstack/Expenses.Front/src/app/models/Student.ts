import { History } from './History';
import { PrintJob } from './PrintJob';
import { Purchase } from './Purchase';

export interface Student {
  id: number;
  name: string;
  balance: number;
  purchases?: Purchase[];
  printJobs?: PrintJob[];
  histories?: History[];
}
