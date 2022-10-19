import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Storage } from '@ionic/storage';

import { UserOptions, userAccount, changePassword } from '../interfaces/account-interface';


@Injectable({
  providedIn: 'root'
})
export class UserData {
  favorites: string[] = [];
  HAS_LOGGED_IN = 'hasLoggedIn';
  HAS_SEEN_TUTORIAL = 'hasSeenTutorial';
  userAccountInfo: userAccount = { username:'', password:'', phone:'', email: '', birthday: '', point: 0 }

  constructor(
    public storage: Storage
  ) { }

  hasFavorite(sessionName: string): boolean {
    return (this.favorites.indexOf(sessionName) > -1);
  }

  addFavorite(sessionName: string): void {
    this.favorites.push(sessionName);
  }

  removeFavorite(sessionName: string): void {
    const index = this.favorites.indexOf(sessionName);
    if (index > -1) {
      this.favorites.splice(index, 1);
    }
  }

  login(login: UserOptions): Promise<any> {
    return this.storage.set(this.HAS_LOGGED_IN, true).then(() => {
      //this.setUsername(loginInfo.username);
      if (login.username == 'first') {
        return window.dispatchEvent(new CustomEvent('user:firstlogin'));
      }
      console.log(login);
      //get userinfo from login
      this.userAccountInfo.username = login.username;
      this.userAccountInfo.email = 'boonyarit75@gmail.com';
      this.userAccountInfo.password = '123456';
      this.userAccountInfo.phone = '0123456789';

      this.setUserInfo(login.username, this.userAccountInfo);

      //detect if is first log in : go to change password
      return window.dispatchEvent(new CustomEvent('user:login'));
    });
  }

  changePassword(loginInfo: changePassword): Promise<any> {
    return this.storage.set(this.HAS_LOGGED_IN, true).then(() => {
      //get token for change password and send api to change password
      return;
    });
  }

  signup(username: string): Promise<any> {
    return this.storage.set(this.HAS_LOGGED_IN, true).then(() => {
      this.setUsername(username);
      return window.dispatchEvent(new CustomEvent('user:signup'));
    });
  }

  logout(): Promise<any> {
    return this.storage.remove(this.HAS_LOGGED_IN).then(() => {
      return this.storage.remove('accountInfo');
    }).then(() => {
      window.dispatchEvent(new CustomEvent('user:logout'));
    });
  }

  setUserInfo(username: string, userAccountInfo: object): Promise<any> {
    return this.storage.set('accountInfo', userAccountInfo);
  }

  setUsername(username: string): Promise<any> {
    return this.storage.set('username', username);
  }

  setPassword(password: string): Promise<any> {
    return this.storage.set('password', password);
  }

  setPhone(phone: string): Promise<any> {
    return this.storage.set('phone', phone);
  }

  //getUsername(): Promise<string> {
  //  //return this.storage.get('username').then((value) => {
  //  //  return value;
  //  //});
  //}

 getUsername(): Promise<string> {
   return this.storage.get('accountInfo').then((value) => {
     console.log(value);
     return value.username;
    });
  }

  isLoggedIn(): Promise<boolean> {
    return this.storage.get(this.HAS_LOGGED_IN).then((value) => {
      return value;
    });
  }

  checkHasSeenTutorial(): Promise<string> {
    return this.storage.get(this.HAS_SEEN_TUTORIAL).then((value) => {
      return value;
    });
  }
}
