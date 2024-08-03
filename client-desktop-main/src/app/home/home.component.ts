import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  languageList = [
    { code: 'en', label: 'English' },
    { code: 'fr', label: 'Français' },
    { code: 'ar', label: 'عـــــــــــــــربي' }
  ];

  constructor(private _router: Router, private _route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  onOptionSelect(optionSelected: string) {
    let navigateTo = "";
    switch (optionSelected) {
      case "info":
      case "payment":
        navigateTo = "./kiosk/kiosk-coupon-collect";
        break;
      case "emergency":
        navigateTo = "./kiosk/kiosk-emergency-menu";
        break;
      case "take-appointment":
      case "have-appointment":
      case "results":
        // navigateTo = "../kiosk-coupon-w-patient";
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
}
