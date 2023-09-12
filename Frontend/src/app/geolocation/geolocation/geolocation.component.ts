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

  latitude: number = this.mapService.getCoords()[0];
  longitude: number = this.mapService.getCoords()[1];
  city: string = "";
  weatherForecast: any;

  ngOnInit(): void {

    if (!navigator.geolocation)
      this.getNotification();

    navigator.geolocation.getCurrentPosition(position => {

      const coords = position.coords;
      const latLong = [coords.latitude, coords.longitude];

      this.mapService.createMap(latLong);

    });

    this.mapService.watchPosition();
  }

  findLocation() {
    this.mapService.updateMap([this.latitude, this.longitude]);
  }

  getNotification() {
    this.notificationService.getNotification();
  }

  sendCity() {
    this.weatherService.getWeatherForCity(this.city)
      .subscribe(response => {
        this.weatherForecast = response;
        this.mapService.updateMap([Number(response.location.lat), Number(response.location.lon)]);
        this.mapService.setLat(Number(response.location.lat));
        this.mapService.setLon(Number(response.location.lon));
        this.latitude = this.mapService.getCoords()[0];
        this.longitude = this.mapService.getCoords()[1];
      });
    ;
  }
}
