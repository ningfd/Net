import { Component, OnInit } from '@angular/core';
import { JournalModel } from '../journal.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Http } from '@angular/http';
import { PlatformLocation } from '@angular/common';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';

@Component({
  selector: 'app-baby-journal-card',
  templateUrl: './baby-journal-card.component.html',
  styleUrls: ['./baby-journal-card.component.css']
})
export class BabyJournalCardComponent implements OnInit {
  journal: JournalModel;
  id: string;
  showStyle: JournalShowStyle;
  http: Http;
  cardForm: FormGroup;
  definParams: any;
  constructor(private routerDirec: Router, private router: ActivatedRoute,
    http: Http, private location: PlatformLocation, private fb: FormBuilder) {
    this.http = http;
    this.router.params.subscribe(params => { this.id = params['id']; });
    this.definParams = {
      saveMark: false
    };
    if (this.id === 'edit') {
      this.showStyle = JournalShowStyle.EditCard;
      this.journal = new JournalModel();
    } else {
      this.loadData(this.id);
      this.showStyle = JournalShowStyle.ReadCard;
    }
    this.cardForm = this.fb.group({
      'title': ['111'],
      'content': ['111']
    });
  }

  ngOnInit() {
  }
  private loadData(id: string): void {
    this.http.get(this.location.pathname + 'api/JournalCard?id=' + id).
      subscribe(
      rep => {
        const josn = rep.json();
        this.journal = josn;
      });
  }
  private submitForm(): void {
    const json = this.cardForm.value;
    console.log(`title:${json.title},content:${json.title}`);
    this.http.post(this.location.pathname + 'api/JournalCard', json).
      subscribe(result => {
        this.definParams.saveMark = result.json();
        if (this.definParams.saveMark) {
          this.routerDirec.navigateByUrl('journallist');
        }
        console.log(`保存结果：${result.json()}`);
      }, error => {
        this.definParams.saveMark = false;
        console.log(`保存结果：失败`);
      });
  }
}
enum JournalShowStyle {
  ReadCard = 1,
  EditCard = 2
}
