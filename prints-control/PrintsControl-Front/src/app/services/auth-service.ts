import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private tokenKey = 'auth.token';

  constructor(private http: HttpClient) {}

  login(email: string, password: string, remember: boolean) {
    return this.http.post<{ token: string }>('/api/auth/login', { email, password }).pipe(
      tap((res) => {
        if (remember) {
          localStorage.setItem(this.tokenKey, res.token);
        }
      })
    );
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }
}
