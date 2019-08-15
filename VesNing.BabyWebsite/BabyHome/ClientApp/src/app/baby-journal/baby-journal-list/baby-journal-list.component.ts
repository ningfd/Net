import { Component, OnInit, Inject } from '@angular/core';
import { JournalModel } from '../journal.model';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { PlatformLocation } from '@angular/common';

@Component({
  selector: 'app-baby-journal-list',
  templateUrl: './baby-journal-list.component.html',
  styleUrls: ['./baby-journal-list.component.css']
})
export class BabyJournalListComponent implements OnInit {
  private id: string;
  private baseUrl: PlatformLocation;
  journalData: any[] = [];
  pageCount: number;
  constructor(private http: Http, baseUrl: PlatformLocation) {
    this.baseUrl = baseUrl;
        // this.router.params.subscribe(params=>this.id=params['id']);
  }
  ngOnInit(): void {
    // this.loadData(1);
    // this.showJournalList();
    this.pageIndexChangedInvoke(1);
  }
  showJournalList(): void {
    const url = this.baseUrl.pathname + 'api/JournalList';
    console.log(url);
    this.http.get(url).subscribe(reuslt => {
      const json: Array<any> = reuslt.json();
      let attstr = '';
      this.journalData = reuslt.json();
      this.journalData.forEach((obj, index) => {
        obj.href = ['../journalcard/', obj.journalID];
        obj.author = '宁凡栋';
        if (obj.content.length >= 100) {
          attstr = '.....' ;
        }
        obj.content = obj.content.substr(0, 100) + attstr;
      });
      // json.forEach((obj, index) => {
      //  var entity = new JournalModel();
      //  entity.journalID = obj.journalID;
      //  entity.href = ['../journalcard/', entity.journalID];
      //  entity.title = obj.title;
      //  entity.content = obj.content;
      //  entity.author = "宁凡栋";
      //  entity.datetime = obj.JournalDate;
      //  this.journalData.push(entity);
      //  return entity;
      // });

    });
  }
  loadData(pi: number): void {
    this.journalData = new Array(5).fill({}).map((i, index) => {
      const entity = new JournalModel();
      entity.journalID = index + '';
      entity.href = ['../journalcard/', entity.journalID];
      entity.title = '日志列表';
      entity.content = '日志记录' + index;
      entity.author = '宁凡栋';
      entity.datetime = new Date();
      return entity;
      /*return {
        href: 'http://ant.design',
        title: `ant design part ${index} (page: ${pi})`,
        avatar: 'https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png',
        description: 'Ant Design, a design language for background applications, is refined by Ant UED Team.',
        content: 'We supply a series of design principles,
         practical patterns and high quality design resources
          (Sketch and Axure), to help people create their product prototypes beautifully and efficiently.'
      };*/
    });
  }
  pageIndexChanged(args) {
    console.log(args);
    this.pageIndexChangedInvoke(args);
  }
  pageIndexChangedInvoke(pageIndex: number): void {
    this.http.get(this.baseUrl.pathname + 'api/JournalList?pageIndex=' + pageIndex + '&pageSize=' + 5).
      subscribe(observe => {
        const result: Array<any> = observe.json();
        let attstr = '';
        this.pageCount = result[0];
        this.journalData = result[1].map((obj, index) => {
          obj.href = ['../journalcard/', obj.journalID];
          obj.author = '宁凡栋';
          if (obj.content.length >= 100) {
            attstr = '.....' ;
          }
          obj.content = obj.content.substr(0, 100) + attstr;
          return obj;
        }, error => {
          console.log(error);
        });
      });
  }
}
