import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-emergency-menu',
  templateUrl: './emergency-menu.component.html',
  styleUrls: ['./emergency-menu.component.css']
})
export class EmergencyMenuComponent implements OnInit {

  constructor(private _router: Router
    , private _route: ActivatedRoute) {
    console.log(this._router.url);
  }

  ngOnInit(): void {
  }

  onOptionSelect(optionSelected: string) {
    let navigateTo = "";
    switch (optionSelected) {
      case "have-yellow-card":
        navigateTo = "";
        break;
      case "yellow-form-request":
      case "information":
        navigateTo = "../kiosk-coupon-collect";
        break;
      case "payment":
        navigateTo = "";
        break;
      default:
        break;
    }

    console.log(navigateTo);
    if (navigateTo !== "") {
      this._router.navigate([navigateTo], {
        relativeTo: this._route
        , queryParams: { serviceSelected: optionSelected }
      });
    }
  }

  onBackClicked() {
    this._router.navigate(['/'], { relativeTo: this._route });
  }

  onExitClicked() {
    this._router.navigate(['/'], { relativeTo: this._route });
  }

}
