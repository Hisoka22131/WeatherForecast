import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../environments/environments";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class WeatherService {


  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) {
  }

  getWeatherForCity(city: string) {
    return this.http.get<any>(this.baseApiUrl + "/weatherForecast/get-weather-forecast/" + city).pipe(
      map(data => ({
        ...data,
        image: `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`
      })),
    );
  }

  getWeatherForLatLong(latLon: number[]) {

    const coord  = {
      latitude: latLon[0],
      longitude: latLon[1]
    };

    return this.http.post<any>(this.baseApiUrl + "/weatherForecast/get-weather-forecast-latLong", coord)
      .pipe(
      map(data => ({
        ...data,
        image: `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`
      })),
    );
  }
}
