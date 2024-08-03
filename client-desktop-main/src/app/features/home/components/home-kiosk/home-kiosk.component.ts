import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home-kiosk',
  templateUrl: './home-kiosk.component.html',
  styleUrls: ['./home-kiosk.component.css']
})
export class HomeKioskComponent implements OnInit {

  languageList = [
    { code: 'en', label: 'English' },
    { code: 'fr', label: 'Français' },
    { code: 'ar', label: 'عـــــــــــــــربي' }
  ];

  constructor(private _router: Router) { }

  ngOnInit(): void {
  }

  onLanguageClicked(selectedLang: string){
    this._router.navigate(['/kiosk'])
    console.log(selectedLang);
  }
}
