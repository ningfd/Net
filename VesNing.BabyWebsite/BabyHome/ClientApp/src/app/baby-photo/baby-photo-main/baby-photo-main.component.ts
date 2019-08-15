import { Component, OnInit } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BabyPhotoComponent } from '../baby-photo-list/baby-photo.component';
import { BabyPhotoHandlerComponent } from '../baby-photo-handler/baby-photo-handler.component';
import { BabyPhotoThumbnailsNavigationGalleryComponent } from '../baby-photo-thumbnails-navigation-gallery/baby-photo-thumbnails-navigation-gallery.component';
@Component({
  selector: 'app-baby-photo-main',
  templateUrl: './baby-photo-main.component.html',
  styleUrls: ['./baby-photo-main.component.css']
})
export class BabyPhotoMainComponent implements OnInit {

  isCollapsed = false;
  isReverseArrow = false;
  width = 200;
  constructor() { }

  ngOnInit() {
  }

}
export const routes: Routes = [
  { path: '', redirectTo: 'journallist', pathMatch: 'full' },
  { path: 'journallist', component: BabyPhotoComponent },
  { path: 'babyphotohandle', component: BabyPhotoHandlerComponent },
  { path: 'babyphotoalbum', component: BabyPhotoThumbnailsNavigationGalleryComponent }
];
