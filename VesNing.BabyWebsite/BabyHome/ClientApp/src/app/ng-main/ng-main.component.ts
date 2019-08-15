import { Component, OnInit, NgModule } from '@angular/core';
import { BabyPhotoComponent } from '../baby-photo/baby-photo-list/baby-photo.component';
import { BabyVideoComponent } from '../baby-video/baby-video.component';
import { BabyJournalCardComponent } from '../baby-journal/baby-journal-card/baby-journal-card.component';
import { BabyJournalListComponent } from '../baby-journal/baby-journal-list/baby-journal-list.component';
import { Routes, RouterModule } from '@angular/router';
import { BabyPhotoHandlerComponent } from '../baby-photo/baby-photo-handler/baby-photo-handler.component';
import { NgLoginComponent } from '../ng-Identity/ng-login/ng-login.component';
import { NgRegisterComponent } from '../ng-Identity/ng-register/ng-register.component';
import { BabyPhotoMainComponent, routes as imageChildren } from '../baby-photo/baby-photo-main/baby-photo-main.component';

@Component({
  selector: 'app-ng-main',
  templateUrl: './ng-main.component.html',
  styleUrls: ['./ng-main.component.css']
})
export class NgMainComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

export const routes: Routes = [
  { path: '', redirectTo: 'journallist', pathMatch: 'full' },
  { path: 'journallist', component: BabyJournalListComponent },
  { path: 'journalcard/:id', component: BabyJournalCardComponent },
  { path: 'journalcard', component: BabyJournalCardComponent },
  { path: 'journal', redirectTo: 'journallist', pathMatch: 'full' },
  { path: 'babyphoto', component: BabyPhotoMainComponent, children: imageChildren }, // BabyPhotoComponent
  { path: 'babyvideo', component: BabyVideoComponent },
  { path: 'babyphotohandle', component: BabyPhotoHandlerComponent }
];
