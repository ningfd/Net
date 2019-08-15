import { Component, OnInit } from '@angular/core';
import {PhotoModel} from './photo.model';
import { Window } from 'selenium-webdriver';


@Component({
  selector: 'app-baby-photo',
  templateUrl: './baby-photo.component.html',
  styleUrls: ['./baby-photo.component.css']
})
export class BabyPhotoComponent implements OnInit {
  data:any[]=[];
  constructor() { }

  ngOnInit() {
    this.loadData();
  }
  loadPic():void
  { 
    
     var file=new FileReader();
     file.onloadend=function(e){
      console.log(this.result);
      console.log(e);
     };
  }
  loadData():void{
     this.data=new Array(15).fill({}).map((i,index)=>{
       var obj=new PhotoModel();
       obj.photoID=index+"";
       obj.title="宁俊哲的照片";
       var path="Image/"+(2+index)+".jpg"
       obj.imageSrc=path;
       obj.description="";
       return obj;
     });
  }
}
