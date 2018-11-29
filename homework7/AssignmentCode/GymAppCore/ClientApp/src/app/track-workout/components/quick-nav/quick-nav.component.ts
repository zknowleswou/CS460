import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Day } from 'src/app/classes/Day';
import { Set } from 'src/app/classes/Set';

@Component({
  selector: 'app-quick-nav',
  templateUrl: './quick-nav.component.html',
  styleUrls: ['./quick-nav.component.css']
})
export class QuickNavComponent implements OnInit {

  @Input() day: Day;
  @Output() goToSet = new EventEmitter<Set>();

  constructor() { }

  ngOnInit() {
  }

  onGoTo(set: Set): void {
    this.goToSet.emit(set);
  }

}
