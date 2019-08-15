import { Component, OnInit } from '@angular/core';
import {JournalModel} from '../journal.model';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-baby-journal-card',
  templateUrl: './baby-journal-card.component.html',
  styleUrls: ['./baby-journal-card.component.css']
})
export class BabyJournalCardComponent implements OnInit {
  journal:JournalModel;
  id:string;
  constructor(private router:ActivatedRoute) { 
    this.router.params.subscribe(params=>{this.id=params['id'];});
    this.journal=new JournalModel();
    this.journal.title="标题";
  }

  ngOnInit() {
  }

}
