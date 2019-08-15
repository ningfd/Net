import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { PlatformLocation } from '@angular/common';
import { Http } from '@angular/http';

@Component({
  selector: 'app-ng-register',
  templateUrl: './ng-register.component.html',
  styleUrls: ['./ng-register.component.css']
})
export class NgRegisterComponent implements OnInit {

  validateForm: FormGroup;
  constructor(private fb: FormBuilder, private location: PlatformLocation, private http: Http) { }

  ngOnInit() {
    this.validateForm = this.fb.group({
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required, this.passWordStrongValidator]],
      confirmPassWord: [null, [Validators.required, this.confirmationValidator]],
      userName: [null, [Validators.required]],
      phoneNumber: [null]
    });
  }
  registerSubmit() {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    const isValid = this.validateForm.valid;
    if (!isValid) {
      return;
    }
    const values = this.validateForm.value;
    this.http.post(this.location.pathname + 'api/account/register', values).
      subscribe(observe => {
        const result = observe.json();
        if (result === true) {
          alert('注册 成功');
        } else {
          alert('注册 失败');
        }
      }, error => {
        alert(error);
      });
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls.password.value) {
      return { confirm: true, error: true };
    }
  }
  passWordStrongValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else {
      const regex = new RegExp('^(?![a-zA-Z]+$)(?![A-Z0-9]+$)(?![A-Z\W_!@#$%^&*`~()-+=]+$)(?![a-z0-9]+$)(?![a-z\W_!@#$%^&*`~()-+=]+$)'+
      '(?![0-9\W_!@#$%^&*`~()-+=]+$)[a-zA-Z0-9\W_!@#$%^&*`~()-+=]{6,30}$');
      if (!regex.exec(control.value)) {
        return { passWordStrong: true, error: true };
      }
    }
  }
}
