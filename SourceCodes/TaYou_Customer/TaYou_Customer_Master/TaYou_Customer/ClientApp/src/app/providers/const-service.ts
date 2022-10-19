import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class ConstService {


    base_url = 'https://restaurantrestapi.herokuapp.com/';

    // base_url = 'http://192.168.1.9:9000/'
  loginType = {
    phone: 'phone',
    username: 'username'
  };


}
