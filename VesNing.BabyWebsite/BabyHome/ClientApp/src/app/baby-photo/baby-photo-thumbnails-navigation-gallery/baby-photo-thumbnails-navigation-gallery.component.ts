import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { PhotoModel } from '../photo.model';
import { Http } from '@angular/http';
import { PlatformLocation } from '@angular/common';

@Component({
  selector: 'app-baby-photo-thumbnails-navigation-gallery',
  templateUrl: './baby-photo-thumbnails-navigation-gallery.component.html',
  styleUrls: ['./baby-photo-thumbnails-navigation-gallery.component.css']
})
export class BabyPhotoThumbnailsNavigationGalleryComponent implements OnInit {

  bigImage: string;
  imageArray: any[] = [];

  $load: any;
  $list: any;
  constructor(private http: Http, private platformLocation: PlatformLocation) {
    this.bigImage = 'Image/' + (2) + '.jpg';
    this.loadDataByServe();
  }
  ngOnInit() {
    this.$load = $('#st_loading');
    this.$list = $('#st_nav');
    this.ImageInit();
  }
  loadData(): void {
    this.imageArray = new Array(15).fill({}).map((i, index) => {
      const obj = new PhotoModel();
      obj.photoID = index + '';
      obj.title = '宁俊哲的照片';
      const path = 'Image/' + (2 + index) + '.jpg';
      obj.imageSrc = path;
      obj.description = '';
      return obj;
    });
  }
  ImageInit(): void {
    const $currImage = $('#st_main').children('img:first');
    $('img').on('load', () => {
      this.$load.hide();
      $currImage.fadeIn(3000);
     this.showBigImage();
      setTimeout(() => {
        this.$list.animate({ 'left': '0px' }, 5000);
      }, 1000);
    }).attr('src', $currImage.attr('src'));
    this.buildThumbs();
    const self = this;
    this.$list.find('.st_arrow_down').bind('click', function () {
      const $this = $(this);
      self.hideThumbs();
      $this.addClass('st_arrow_up').removeClass('st_arrow_down');
      const $elem = $this.closest('li');
      $elem.addClass('current').animate({ 'height': '170px' }, 200);
      const $thumbs_wrapper = $this.parent().next();
      $thumbs_wrapper.show(200);
    });
    this.$list.find('.st_arrow_up').bind('click', function () {
      const $this = $(this);
      $this.addClass('st_arrow_down').removeClass('st_arrow_up');
      self.hideThumbs();
    });
  }
  buildThumbs() {
    this.$list.children('li.album').each(() => {
      const $elem = $(this);
      const $thumbs_wrapper = $elem.find('.st_thumbs_wrapper');
      const $thums = $thumbs_wrapper.children(':first');
      const finalW = 200; // $thums.find('img').length * 183;
      $thums.css('width', finalW + 'px');
      this.makeScrollable($thumbs_wrapper, $thums);
    });
  }
  makeScrollable($outer: any, $inner: any) {
    const extra = 8000;
    const divWidth = $outer.width();
    $outer.css({ overflow: 'hidden' });
    const lastElem = $inner.find('img:last');
    const scrollX = $('#st_main').position().left;
    console.log(scrollX);
    $outer.scrollLeft(scrollX);
    $outer.unbind('mousemove').bind('mousemove', (e) => {
      const containerWidth = lastElem[0].offsetLeft + lastElem.outerWidth() + 2 * extra;
      const left = (e.pageX - $outer.offset().left) * (containerWidth - divWidth) / divWidth - extra;
      $outer.scrollLeft(left);
    });
  }
  hideThumbs() {
    this.$list.find('li.current')
      .animate({ 'height': '50px' }, 400, function () {
        $(this).removeClass('current');
      })
      .find('.st_thumbs_wrapper')
      .hide(200)
      .addBack()
      .find('.st_link span')
      .addClass('st_arrow_down')
      .removeClass('st_arrow_up');
  }
  showBigImage() {
    const self = this;
    // clicking on a thumb, replaces the large image
    console.log('img length' + $('.st_thumbs_img').length);
    console.log('st_preview length' + $('.st_preview').length);
    this.$list.find('.st_thumbs img').on('click', function () {
      const $this = $(this);
      self.$load.css('display', 'show');
      console.log('======st_preview length=====' + $('.st_preview').length);
      $('<img class="st_preview" style="width:800px;height:600px;"/>').on('load', function () {
        const _$this = $(this);
        const _$currImage = $('#st_main').children('img:first');
        _$this.insertBefore(_$currImage);
        self.$load.hide();
        _$currImage.fadeOut(0, function () {
          $(this).remove();
        });
      }).attr('src', $this.attr('src'));
    }).bind('mouseenter', function () {
      $(this).stop().animate({ 'opacity': '1' });
    }).bind('mouseleave', function () {
      $(this).stop().animate({ 'opacity': '0.7' });
    });
  }

  loadDataByServe(): void {
    this.http.get(this.platformLocation.pathname + 'api/BabyPhoto/showImage').
      subscribe(observe => {
        const result: Array<any> = observe.json();
        this.imageArray = result.map((i, index) => {
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
