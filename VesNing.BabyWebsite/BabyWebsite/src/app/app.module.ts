import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData, PathLocationStrategy, LocationStrategy, HashLocationStrategy } from '@angular/common';
import en from '@angular/common/locales/en';
import { BabyPhotoComponent } from './baby-photo/baby-photo.component';
import { BabyVideoComponent } from './baby-video/baby-video.component';
import { NgMenuComponent } from './ng-menu/ng-menu.component';
import { BabyJournalCardComponent } from './baby-journal/baby-journal-card/baby-journal-card.component';
import { BabyJournalListComponent } from './baby-journal/baby-journal-list/baby-journal-list.component';
import {Routes,RouterModule} from '@angular/router';

registerLocaleData(en);
const routes:Routes=[
  {path:'',redirectTo:'journallist',pathMatch:'full'},
  {path:'journallist',component:BabyJournalListComponent},
  {path:'journalcard/:id',component:BabyJournalCardComponent},
  {path:'journal',redirectTo:'journallist',pathMatch:'full'},
  {path:'babyphoto',component:BabyPhotoComponent},
  {path:'babyvideo',component:BabyVideoComponent}
];
@NgModule({
  declarations: [
    AppComponent,
    BabyPhotoComponent,
    BabyVideoComponent,
    NgMenuComponent,
    BabyJournalCardComponent,
    BabyJournalListComponent
  ],
  imports: [
    BrowserModule,
    NgZorroAntdModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US },
             {provide:LocationStrategy,useClass:HashLocationStrategy}],
  bootstrap: [AppComponent]
})
export class AppModule { }
