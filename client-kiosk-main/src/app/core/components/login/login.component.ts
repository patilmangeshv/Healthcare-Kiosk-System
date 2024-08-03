import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { Login } from '../../models/login';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  /**
   * Type of the application
   * iptv: 0
   * kiosk: 1
   * deskuser: 2
   * doctoruser: 3
   * qms: 4
   */
  @Input("applicationType") applicationType: number = 1;
  isLoading: boolean = false;
  errorMessage: string = "";
  private userSub: Subscription | undefined;

  constructor(
    private _authService: AuthService,
    private _router: Router
  ) { }

  ngOnInit() {
    // // 1. Method for subscribing to the user for any change value
    // this.userSub = this._authService.user.subscribe(user => {
    //   if (user) {
    //     console.log("User is logged in with name: " + user.username);
    //   }
    // });

    // // 2. Method for immediate subscribing and getting value and immediate unsubscribing the subscription
    // this._authService.user.pipe(take(1)).subscribe(user => {
    //   if (user) {
    //     console.log("User is logged in with name using one time subscrption: " + user.username);
    //   } {
    //     console.log("No user information available");
    //   }
    // });
  }

  ngOnDestroy() {
    if (this.userSub) this.userSub.unsubscribe();
  }

  onSubmit(form: NgForm) {
    console.warn(form.value);

    if (!form.valid) return;

    this.isLoading = true;

    let loginData: Login = new Login(this.applicationType, form.value.username, form.value.password, form.value.macaddress);

    this._authService.login(loginData)
      .subscribe(response => {
        this.isLoading = false;
        this.errorMessage = "";

        this._router.navigate(["/"]);
      }, errorMessage => {
        this.isLoading = false;
        this.errorMessage = errorMessage;
      });
  }
}