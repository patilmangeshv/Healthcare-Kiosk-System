import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private _router: Router
    , private _route: ActivatedRoute
  ) { }

  ngOnInit(): void {
  }

  onOptionSelect(optionSelected: string) {
    let navigateTo = "";
    switch (optionSelected) {
      case "info":
      case "payment":
        navigateTo = "../kiosk-coupon-collect";
        break;
      case "emergency":
        navigateTo = "../kiosk-emergency-menu";
        break;
      case "take-appointment":
      case "have-appointment":
      case "results":
        // navigateTo = "../kiosk-coupon-w-patient";
        break;

      default:
        break;
    }

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
