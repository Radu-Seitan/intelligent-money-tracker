import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'IMT-Frontend';
  showPassword: boolean = true;


  getInputType() {
    if (this.showPassword) {
      return 'text';
    }
    return 'password';

  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }
}
