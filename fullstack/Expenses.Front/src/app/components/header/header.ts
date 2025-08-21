import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [
    RouterModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatMenuModule,
    CommonModule,
    MatDividerModule,
  ],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  isLoggedIn = false;

  login() {
    console.log('Fazendo login...');
    this.isLoggedIn = true;
  }

  logout() {
    console.log('Fazendo logout...');
    this.isLoggedIn = false;
  }
  constructor(private router: Router) {}

  showMenu = false;

  goHome() {
    this.router.navigate(['/students']);
  }

  addStudent() {
    this.router.navigate(['/students/add']);
  }

  addPurchase() {
    this.router.navigate(['/purchases/add']);
  }

  printJob() {
    this.router.navigate(['/students/add/print']);
  }

  openHistory() {
    this.router.navigate(['/students/history']);
  }

  onLogout() {
    alert('Fazer novas implementações caso Senac se interessar');
    this.router.navigate(['/students']);
  }

  onLogin() {
    alert('Fazer novas implementações caso Senac se interessar');
    this.router.navigate(['/students']);
  }
}
