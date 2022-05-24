import {Component} from '@angular/core';
import {AuthService} from "../../modules/auth/services/auth.service";

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent {

  constructor(readonly _authService: AuthService) {
  }
}
