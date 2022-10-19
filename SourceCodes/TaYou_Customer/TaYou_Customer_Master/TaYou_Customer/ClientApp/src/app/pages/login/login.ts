import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { UserData } from '../../providers/user-data';

import { UserOptions } from '../../interfaces/account-interface';
import { Md5 } from 'ts-md5/dist/md5';

@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
  styleUrls: ['./login.scss'],
})
export class LoginPage {
  loginForm: UserOptions = {
    username: '', password: '', phone: '', loginType: ''
  };
  submitted = false;

  constructor(
    public userData: UserData,
    public router: Router
  ) { }

  onLogin(form: NgForm) {
    this.submitted = true;
    if (form.valid) {
      const md5 = new Md5();
      console.log(this.loginForm);
      console.log(form);
      this.loginForm.username = form.value.username;
      this.loginForm.password = form.value.password;
      console.log(this.loginForm);
      console.log(form);
      this.userData.login(this.loginForm);
      this.submitted = false;
      form.resetForm();
    }
  }

  onSignup() {
    this.router.navigateByUrl('/signup');
  }
}
