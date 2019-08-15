import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { PlatformLocation } from '@angular/common';

import { AppComponent } from './app.component';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData, PathLocationStrategy, LocationStrategy, HashLocationStrategy } from '@angular/common';
import en from '@angular/common/locales/en';
import { BabyPhotoComponent } from './baby-photo/baby-photo-list/baby-photo.component';
import { BabyVideoComponent } from './baby-video/baby-video.component';
import { NgMenuComponent } from './ng-menu/ng-menu.component';
import { BabyJournalCardComponent } from './baby-journal/baby-journal-card/baby-journal-card.component';
import { BabyJournalListComponent } from './baby-journal/baby-journal-list/baby-journal-list.component';
import { BabyPhotoHandlerComponent } from './baby-photo/baby-photo-handler/baby-photo-handler.component';
import { NgLoginComponent } from './ng-Identity/ng-login/ng-login.component';
import { NgRegisterComponent } from './ng-Identity/ng-register/ng-register.component';
import { AppRoutingModule } from './ng-router/app-routing.module';
import { NgMainComponent } from './ng-main/ng-main.component';
import { BabyPhotoMainComponent } from './baby-photo/baby-photo-main/baby-photo-main.component';
import { BabyPhotoThumbnailsNavigationGalleryComponent } from './baby-photo/baby-photo-thumbnails-navigation-gallery/baby-photo-thumbnails-navigation-gallery.component';

registerLocaleData(en);
@NgModule({
  declarations: [
    AppComponent,
    BabyPhotoComponent,
    BabyVideoComponent,
    NgMenuComponent,
    BabyJournalCardComponent,
    BabyJournalListComponent,
    BabyPhotoHandlerComponent,
    NgLoginComponent,
    NgRegisterComponent,
    NgMainComponent,
    BabyPhotoMainComponent,
    BabyPhotoThumbnailsNavigationGalleryComponent
  ],
  imports: [
    BrowserModule,
    NgZorroAntdModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {

  return document.getElementsByTagName('base')[0].href;
}
