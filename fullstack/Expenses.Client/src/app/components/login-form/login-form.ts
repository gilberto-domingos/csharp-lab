import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service';

@Component({
  selector: 'app-login-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCard,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  templateUrl: './login-form.html',
  styleUrl: './login-form.scss',
  standalone: true,
})
export class LoginForm implements OnInit {
  form!: FormGroup;
  loading = false;
  errorMessage = '';

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {}

  // É um login básico caso houver interesse do senac vou implementar hash Token JWT de forma profissional
  ngOnInit() {
    const token = this.auth.getToken();
    if (token) {
      this.router.navigate(['/students']);
      return;
    }

    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      rememberMe: [true],
    });
  }

  // É um login básico caso houver interesse do senac vou implementar hash Token JWT de forma profissional
  onSubmit() {
    if (this.form.invalid) return;

    this.loading = true;
    const { email, password, rememberMe } = this.form.value;

    if (password === 'aluno2025gilberto') {
      //  if (rememberMe) {
      localStorage.setItem('auth.token', 'fake-token-123');
      localStorage.setItem('auth.user', email);
      // }

      this.router.navigate(['/students']);
    } else {
      alert('Você não tem autorização, somente coordenador, professores e funcionários');
      // this.errorMessage = 'Usuário ou senha inválidos';
    }

    /* onSubmit() {
    if (this.form.invalid) return;

    this.loading = true;
    const { email, password, rememberMe } = this.form.value;

    this.auth.login(email, password, rememberMe).subscribe({
      next: () => {
        this.router.navigate(['/student']);
      },
      error: (err) => {
        this.errorMessage = 'Usuário ou senha inválidos';
        this.loading = false;
      },
    });*/
  }
}
