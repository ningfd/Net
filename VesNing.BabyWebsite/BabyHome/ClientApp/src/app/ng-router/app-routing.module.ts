import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { registerLocaleData, PathLocationStrategy, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { BabyPhotoComponent } from '../baby-photo/baby-photo-list/baby-photo.component';
import { BabyVideoComponent } from '../baby-video/baby-video.component';
import { BabyJournalCardComponent } from '../baby-journal/baby-journal-card/baby-journal-card.component';
import { BabyJournalListComponent } from '../baby-journal/baby-journal-list/baby-journal-list.component';
import { Routes, RouterModule } from '@angular/router';
import { BabyPhotoHandlerComponent } from '../baby-photo/baby-photo-handler/baby-photo-handler.component';
import { NgLoginComponent } from '../ng-Identity/ng-login/ng-login.component';
import { NgRegisterComponent } from '../ng-Identity/ng-register/ng-register.component';
import { NgMainComponent, routes as MainChildren } from '../ng-main/ng-main.component';
import { LoggedInGuard } from '../ng-Identity/ng-login/logged-in-guard';

export const routes: Routes = [

  // { path: '', redirectTo: 'journallist', pathMatch: 'full' },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: NgLoginComponent },
  { path: 'register', component: NgRegisterComponent },
  {
    path: 'main', component: NgMainComponent, children: MainChildren // , canActivate: [LoggedInGuard]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  providers: [LoggedInGuard,
    { provide: LocationStrategy, useClass: HashLocationStrategy }]
})
export class AppRoutingModule { }
