import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { PlatformLocation } from '@angular/common';
import { Http } from '@angular/http';

@Component({
  selector: 'app-ng-login',
  templateUrl: './ng-login.component.html',
  styleUrls: ['./ng-login.component.css']
})
export class NgLoginComponent implements OnInit {

  validateForm: FormGroup;
  objValidate: any;
  constructor(private fb: FormBuilder, private router: Router,
    private location: PlatformLocation, private http: Http) {
      this.objValidate={
        LoginErrorResult:''
      };
  }

  ngOnInit() {
    this.validateForm = this.fb.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      remember: [true]

    });
  }
  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    if (!this.validateForm.valid) {
      return;
    }
    const values = this.validateForm.value;
    this.http.post(this.location.pathname + 'api/account/login', values).
      subscribe(observe => {
        const result: string = observe.text();
        if (result === "Success") {
      console.log("登录成功！");
      this.router.navigateByUrl('main');
    } else if (result === "AccountMiss") {
      this.objValidate.LoginErrorResult = '账号不存在！';
    } else if (result === "PassWordError") {
      this.objValidate.LoginErrorResult = '密码错误';
    }
  }, error => {
  alert(error);
});
  }

}
