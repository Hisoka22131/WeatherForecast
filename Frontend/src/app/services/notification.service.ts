import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() { }

  getNotification() {
    Notification.requestPermission()
      .then(function () {

        new Notification('Ошибка', {
          body: 'Не найдено местоположение',
          icon: 'путь_к_иконке.png'
        });

      });
  }
}
