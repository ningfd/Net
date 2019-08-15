import { Component, OnInit } from '@angular/core';
import { JournalModel } from '../journal.model';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-baby-journal-list',
  templateUrl: './baby-journal-list.component.html',
  styleUrls: ['./baby-journal-list.component.css']
})
export class BabyJournalListComponent implements OnInit {
private id:string;
  constructor() { 
        //this.router.params.subscribe(params=>this.id=params['id']);
  }
  data: any[] = [];

  ngOnInit(): void {
    this.loadData(1);
  }

  loadData(pi: number): void {
    this.data = new Array(5).fill({}).map((i, index) => {
      var entity=new JournalModel();
      entity.journalID=index+"";
      entity.href=['../journalcard/',entity.journalID];
      entity.title="宝宝出生日";
      entity.content="2018.11.23.21:09 宁怀瑾出生啦！"+index;
      entity.author="宁凡栋";
      entity.datetime=new Date();
      return entity;
      /*return {
        href: 'http://ant.design',
        title: `ant design part ${index} (page: ${pi})`,
        avatar: 'https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png',
        description: 'Ant Design, a design language for background applications, is refined by Ant UED Team.',
        content: 'We supply a series of design principles, practical patterns and high quality design resources (Sketch and Axure), to help people create their product prototypes beautifully and efficiently.'
      };*/
    });
  }
}
