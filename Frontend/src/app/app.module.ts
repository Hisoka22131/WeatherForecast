import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NgxMapLibreGLModule} from '@maplibre/ngx-maplibre-gl';
import {GeolocationComponent} from './geolocation/geolocation/geolocation.component';

@NgModule({
  declarations: [
    AppComponent,
    GeolocationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxMapLibreGLModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
