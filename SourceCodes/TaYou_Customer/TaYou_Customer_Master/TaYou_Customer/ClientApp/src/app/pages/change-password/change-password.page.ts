import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { changePassword } from '../../interfaces/account-interface';
import { Router } from '@angular/router';

import { UserData } from '../../providers/user-data';
import { Md5 } from 'ts-md5/dist/md5';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.page.html',
  styleUrls: ['./change-password.page.scss'],
})
export class ChangePasswordPage implements OnInit {
  changePasswordForm: changePassword = {
    oldPassword: '', newPassword: '', confirmPassword: '', token: ''
  }
  submitted = false;

  constructor(
    public userData: UserData,
    public router: Router
  ) { }

  ngOnInit() {
  }

  onChangePassword(form: NgForm) {
    this.submitted = true;
    if (form.valid && (form.value.newPassword == form.value.confirmPassword)) {
      this.changePasswordForm.newPassword = form.value.newPassword;
      this.changePasswordForm.confirmPassword = form.value.confirmPassword;
      const md5 = new Md5();
      //console.log(md5.appendStr('test1').end());
      console.log(this.changePasswordForm);
      this.userData.changePassword(this.changePasswordForm);
      this.submitted = false;
      form.resetForm();
      console.log(this.changePasswordForm);
    }
  }

}
