import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CallMyApiComponent } from './call-my-api/call-my-api.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CallMyApiComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngularUI';
}
