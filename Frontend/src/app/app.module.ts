import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {GeolocationComponent} from './components/geolocation/geolocation.component';
import {BsDropdownModule} from "ngx-bootstrap/dropdown";
import {HttpClientModule} from "@angular/common/http";
import {MapService} from "./services/map.service";
import {FormsModule} from "@angular/forms";
import {NotificationService} from "./services/notification.service";
import {WeatherService} from "./services/weather.service";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import { WeatherComponent } from './components/weather/weather.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { WeatherDetailComponent } from './components/weather-detail/weather-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    GeolocationComponent,
    WeatherComponent,
    NavbarComponent,
    WeatherDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BsDropdownModule.forRoot(),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule
  ],
  providers: [
    MapService,
    NotificationService,
    WeatherService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
