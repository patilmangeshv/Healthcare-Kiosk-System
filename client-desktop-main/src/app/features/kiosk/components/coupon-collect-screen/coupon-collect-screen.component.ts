import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-coupon-collect-screen',
  templateUrl: './coupon-collect-screen.component.html',
  styleUrls: ['./coupon-collect-screen.component.css']
})
export class CouponCollectScreenComponent implements OnInit {

  serviceSelected: string = "";
  constructor(private _router: Router
    , private _route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this._route.queryParams
      .subscribe((params: Params) => {
        this.serviceSelected = params["serviceSelected"];
      })
  }

  ngAfterViewInit() {
    this.printDocument();
  }

  printDocument() {
    window.print();
  }

  onExitClicked() {
    this._router.navigate(['/'], { relativeTo: this._route });
  }
}
