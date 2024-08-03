import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { CoreRoutingModule } from './core-routing.module';
import { ConfigService } from './services/config.service';
import { ApiDataService } from './services/apidata.service';
import { LoginComponent } from './components/login/login.component';

/**
 * Sets configuration settings by reading config file before application launch
 * @param config Instance of 'ConfigService' service
 * @tutorial For more information https://www.intertech.com/Blog/angular-4-tutorial-run-code-during-app-initialization/
 */
export function initConfig(config: ConfigService) {
  return () => config.loadConfigSettings();
}

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    CoreRoutingModule
  ],
  providers: [
    ApiDataService,
    // Register a service provider with injector. The injector relies on 'providers' to create instances of the services that the injector injects into components and other services.
    // Note : There is only one instance of below services and this single instance is shared among others by using dependancy injection of Angular.
    ConfigService, { provide: APP_INITIALIZER, useFactory: initConfig, deps: [ConfigService], multi: true },
  ]
})
export class CoreModule { }
