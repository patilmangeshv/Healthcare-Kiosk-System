import { Component, OnInit } from '@angular/core';

import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: ['./loading-spinner.component.css']
})
export class LoadingSpinnerComponent implements OnInit {

  constructor(private _spinner: NgxSpinnerService) { }

  ngOnInit(): void {
  }

  showSpinner() {
    this._spinner.show();
  }

  hideSpinner() {
    this._spinner.hide();
  }
}
