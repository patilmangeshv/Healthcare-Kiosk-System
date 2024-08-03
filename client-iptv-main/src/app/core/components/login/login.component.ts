import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { Login } from '../../models/login';
import { Desk } from '../../models/desk';
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
  @Input("applicationType") applicationType: number = 0;
  isLoading: boolean = false;
  errorMessage: string = "";
  desks: Desk[] = [];

  private userSub: Subscription | undefined;

  constructor(
    private _authService: AuthService,
    private _router: Router
  ) { }

  async ngOnInit() {
    this._authService.getDesks()
      .subscribe((data: any) => {
        this.desks = [];
        data.forEach((deskData: any) => {
          this.desks.push(new Desk(deskData.id, deskData.deskCode, deskData.deskName));
        });
      }, error => {
        this.errorMessage = "Error while fetching desks!";
        console.log("Error while fetching desks:");
        console.log(error);
      });
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
    if (!form.valid) return;

    let isValid: boolean = false;
    switch (this.applicationType) {
      case 0: // iptv
        // 1. macaddress and deskcode are mandatory
        if (form.value.macaddress == "") {
          // form.control.macaddress.isValid=false;
          this.errorMessage = "Mac address is mandatory!";
        } else if (form.value.deskCode == "") {
          this.errorMessage = "Desk code is mandatory!";
        } else {
          isValid = true;
          this.errorMessage = "";
        }
        break;

      default:
        isValid = true;
        break;
    }
    if (isValid) {
      this.isLoading = true;

      let loginData: Login = new Login(this.applicationType, form.value.username, form.value.password, form.value.macaddress
        , form.value.deskCode, "X"); //X: dummy box code for temp purpose

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
}