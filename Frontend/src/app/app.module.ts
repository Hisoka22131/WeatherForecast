import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {GeolocationComponent} from './geolocation/geolocation/geolocation.component';
import {BsDropdownModule} from "ngx-bootstrap/dropdown";
import {NavbarComponent} from './navbar/navbar.component';
import {HttpClientModule} from "@angular/common/http";
import {MapService} from "./services/map.service";
import {FormsModule} from "@angular/forms";
import {NotificationService} from "./services/notification.service";

@NgModule({
  declarations: [
    AppComponent,
    GeolocationComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BsDropdownModule.forRoot(),
    HttpClientModule,
    FormsModule
  ],
  providers: [
    MapService,
    NotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
