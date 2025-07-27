import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-drafts',
  imports: [MatButtonModule, MatIconModule, MatToolbarModule],
  templateUrl: './drafts.html',
  styleUrl: './drafts.scss',
})
export class Drafts {}
