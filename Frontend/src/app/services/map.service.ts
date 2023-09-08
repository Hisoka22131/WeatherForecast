import {Injectable} from '@angular/core';

declare const L: any;

@Injectable({
  providedIn: 'root'
})
export class MapService {

  map: any;

  constructor() {
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

    this.map = map;
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

  updateMap(latLong: number[]) {

    this.map.setView(new L.LatLng(latLong[0], latLong[1]), 10);

    L.marker(latLong).addTo(this.map);

    L.popup()
      .setLatLng(latLong)
      .setContent("Не ваше местоположение")
      .openOn(this.map);
  }

}
