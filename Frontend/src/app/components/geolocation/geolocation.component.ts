import {Component, OnInit} from '@angular/core';
import {MapService} from "../../services/map.service";
import {NotificationService} from "../../services/notification.service";
import {WeatherService} from "../../services/weather.service";

@Component({
  selector: 'app-geolocation',
  templateUrl: './geolocation.component.html',
  styleUrls: ['./geolocation.component.css']
})
export class GeolocationComponent implements OnInit {

  constructor(private mapService: MapService,
              private weatherService: WeatherService,
              private notificationService: NotificationService) {

  }

  city: string = "";
  weather: any;

  ngOnInit(): void {

    if (!navigator.geolocation)
      this.getNotification();

    navigator.geolocation.getCurrentPosition(position => {

      const coords = position.coords;
      const latLong = [coords.latitude, coords.longitude];

      this.weatherService.getWeatherForLatLong(latLong)
        .subscribe(response => this.weather = response);

      this.mapService.createMap(latLong);

    });

    this.mapService.watchPosition();
  }

  getNotification() {
    this.notificationService.getNotification();
  }

  sendCity() {
    this.weatherService.getWeatherForCity(this.city)
      .subscribe(response => {
        this.weather = response;
        this.mapService.updateMap([Number(response.coord.lat), Number(response.coord.lon)]);
      });
  }
}
