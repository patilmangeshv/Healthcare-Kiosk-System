import { Component, OnInit } from '@angular/core';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(
    private _authService: AuthService
  ) { }

  ngOnInit(){
    
    // auto login user if already logged in
    this._authService.autoLogin();

  }
}
