import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {GeolocationComponent} from './components/geolocation/geolocation.component';
import {WeatherDetailComponent} from "./components/weather-detail/weather-detail.component";

const routes: Routes = [
  {path: '', component: GeolocationComponent},
  {path: 'detail', component: WeatherDetailComponent},
  {path: '**', component: GeolocationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
