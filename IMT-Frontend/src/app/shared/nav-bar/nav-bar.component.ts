import {Component} from '@angular/core';
import {AuthService} from "../../modules/auth/services/auth.service";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  readonly LOGO_PATH = 'assets/images/big_logo.svg'

  constructor(
    readonly _authService: AuthService,
  ) {
  }
}
