import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [RouterModule, MatButtonModule, MatIconModule, MatToolbarModule],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  onAddTransaction() {
    console.log('Add Transaction clicked');
    // lógica para abrir form ou navegar
  }

  onLogout() {
    console.log('Logout clicked');
    // lógica de logout
  }

  onLogin() {
    console.log('Login clicked');
    // lógica de login
  }
}
