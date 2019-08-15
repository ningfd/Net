import { Component, OnInit } from '@angular/core';
import { PhotoModel } from '../photo.model';
import { Http } from '@angular/http';
import { PlatformLocation } from '@angular/common';

@Component({
  selector: 'app-baby-photo',
  templateUrl: './baby-photo.component.html',
  styleUrls: ['./baby-photo.component.css']
})
export class BabyPhotoComponent implements OnInit {
  data: any[] = [];
  previewImage = '';
  previewVisible = false;

  pageCount: number;
  constructor(private http: Http, private platformLocation: PlatformLocation) {

  }

  ngOnInit() {
    // this.loadData();
    // this.loadDataByServe();
    this.pageIndexChangedInvoke(1);
  }
  loadPic(): void {
    const file = new FileReader();
    file.onloadend = function (e) {
      console.log(this.result);
      console.log(e);
    };
  }
  loadData(): void {
    this.data = new Array(15).fill({}).map((i, index) => {
      const obj = new PhotoModel();
      obj.photoID = index + '';
      obj.title = '宁俊哲的照片';
      const path = 'Image/' + (2 + index) + '.jpg';
      obj.imageSrc = path;
      obj.description = '';
      return obj;
    });
  }
  loadDataByServe(): void {
    this.http.get(this.platformLocation.pathname + 'api/BabyPhoto').
      subscribe(observe => {
        const result: Array<any> = observe.json();
        this.data = result.map((i, index) => {
          const obj = new PhotoModel();
          obj.photoID = i.id;
          obj.title = i.photoName;
          // let path = "Image/" + (2 + index) + ".jpg"
          obj.imageSrc = i.url;
          obj.description = '';
          return obj;
        }, error => {
          console.log(error);
        });
      });
  }
  showModal(obj: any) {
    this.previewVisible = true;
    this.previewImage = obj.imageSrc;
    // el.style.visibility = 'visible';
  }
  pageIndexChanged(args) {
    console.log(args);
    this.pageIndexChangedInvoke(args);
  }
  pageIndexChangedInvoke(pageIndex: number): void {
    this.http.get(this.platformLocation.pathname + 'api/BabyPhoto?pageIndex=' + pageIndex + '&pageSize=' + 12).
      subscribe(observe => {
        const result: Array<any> = observe.json();
        this.pageCount = result[0];
        this.data = result[1].map((i, index) => {
          const obj = new PhotoModel();
          obj.photoID = i.id;
          obj.title = i.photoName;
          // let path = "Image/" + (2 + index) + ".jpg"
          obj.imageSrc = i.url;
          obj.description = '';
          return obj;
        }, error => {
          console.log(error);
        });
      });
  }
}
