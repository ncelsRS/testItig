import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgModule} from '@angular/core';

import {AgmCoreModule} from '@agm/core';
import {CalendarModule} from 'angular-calendar';

import {routing} from './app.routing';
import {AppSettings} from './app.settings';

import {AppComponent} from './app.component';
import {NotFoundComponent} from './pages/errors/not-found/not-found.component';
import {IdentityModule} from "./shared/identity/identity.module";
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    IdentityModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDe_oVpi9eRSN99G4o6TwVjJbFBNr58NxE'
    }),
    CalendarModule.forRoot(),
    routing
  ],
  providers: [AppSettings],
  bootstrap: [AppComponent]
})
export class AppModule {
}
