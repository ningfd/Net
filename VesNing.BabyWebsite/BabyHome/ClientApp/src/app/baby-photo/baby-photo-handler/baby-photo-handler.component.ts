import { Component, OnInit } from '@angular/core';
import { NzMessageService, UploadFile } from 'ng-zorro-antd';
import { Observable, Observer } from 'rxjs';
import { PlatformLocation } from '@angular/common';

@Component({
  selector: 'app-baby-photo-handler',
  templateUrl: './baby-photo-handler.component.html',
  styleUrls: ['./baby-photo-handler.component.css']
})
export class BabyPhotoHandlerComponent implements OnInit {
  fileList = [
    {
      uid: -1,
      name: 'xxx.png',
      status: 'done',
      url: 'https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png'
    }
  ];
  previewImage = '';
  previewVisible = false;
  serverUrl: string;
  constructor(private msg: NzMessageService, private platFormLocation: PlatformLocation) {
    this.serverUrl = this.platFormLocation.pathname + 'api/BabyPhoto';
    console.log(this.serverUrl);
  }
  ngOnInit() {

  }
  handlePreview = (file: UploadFile) => {
    this.previewImage = file.url || file.thumbUrl;
    this.previewVisible = true;
    console.log(this.serverUrl);
  }
}
