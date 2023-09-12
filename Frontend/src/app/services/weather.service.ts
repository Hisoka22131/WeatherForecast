import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MapService} from "./map.service";
import {environment} from "../environments/environments";

@Injectable({
  providedIn: 'root'
})
export class WeatherService {


  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) {
  }

  getWeatherForCity(city: string) {
    return this.http.get<any>(this.baseApiUrl + "/weatherForecast/get-weather-forecast/" + city);
  }
}
