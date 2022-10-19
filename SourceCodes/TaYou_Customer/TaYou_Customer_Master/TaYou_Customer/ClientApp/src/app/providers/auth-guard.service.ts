import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot } from "@angular/router";

import { UserData } from './user-data';

@Injectable({
  providedIn: "root"
})
export class AuthGuardService implements CanActivate {
  constructor(private router: Router,private userdata: UserData) { }

  canActivate(route: ActivatedRouteSnapshot): Promise<boolean> {
    return this.userdata.isLoggedIn().then
      ((value) => {
        if (value) {
          console.log('AuthGuardService:true');
          return true;
        }
        else {
          console.log('AuthGuardService:false');
          window.dispatchEvent(new CustomEvent('user:logout'));
          return false;
        }
      }
      );
  }
}
