import {Component, OnInit} from '@angular/core';

declare const L: any;

@Component({
  selector: 'app-geolocation',
  templateUrl: './geolocation.component.html',
  styleUrls: ['./geolocation.component.css']
})
export class GeolocationComponent implements OnInit {
  ngOnInit(): void {

    if (!navigator.geolocation)
      this.getNotification();

    navigator.geolocation.getCurrentPosition(position => {

      const coords = position.coords;
      const latLong = [coords.latitude, coords.longitude];

      this.createMap(latLong);

    });

    this.watchPosition();
  }

  watchPosition() {
    let desLat = 0;
    let desLon = 0;

    let id = navigator.geolocation.watchPosition(position => {

      if (position.coords.latitude === desLat)
        navigator.geolocation.clearWatch(id);

    }, (error => console.log(error)), {
      enableHighAccuracy: true,
      timeout: 5000,
      maximumAge: 0
    });
  }

  createMap(latLong: number[]) {
    let map = L.map('map').setView(latLong, 10);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);

    let marker = L.marker(latLong).addTo(map);

    marker.bindPopup('<br>Ваше местоположение</br>').openPopup();

    L.popup()
      .setLatLng(latLong)
      .setContent("Ваше местоположение")
      .openOn(map);
  }

  getNotification() {
    Notification.requestPermission()
      .then(function () {

        new Notification('Ошибка', {
          body: 'Не найдено местоположение',
          icon: 'путь_к_иконке.png'
        });

      })
      .catch(function (error) {
        console.error('Ошибка при запросе разрешения на уведомления:', error);
      });
  }
}
