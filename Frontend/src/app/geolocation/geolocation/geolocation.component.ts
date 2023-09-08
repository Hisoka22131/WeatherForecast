import {Component, OnInit} from '@angular/core';
import {MapService} from "../../services/map.service";
import {NotificationService} from "../../services/notification.service";

@Component({
  selector: 'app-geolocation',
  templateUrl: './geolocation.component.html',
  styleUrls: ['./geolocation.component.css']
})
export class GeolocationComponent implements OnInit {

  latitude: number = 46.8642115;
  longitude: number = 45.6150736;

  constructor(private mapService: MapService,
              private notificationService: NotificationService) {
  }

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
}
