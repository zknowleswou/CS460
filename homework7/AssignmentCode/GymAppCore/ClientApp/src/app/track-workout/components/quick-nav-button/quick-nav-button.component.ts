import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Exercise } from 'src/app/classes/Exercise';
import {Set } from '../../../classes/Set';

@Component({
  selector: 'app-quick-nav-button',
  templateUrl: './quick-nav-button.component.html',
  styleUrls: ['./quick-nav-button.component.css']
})
export class QuickNavButtonComponent implements OnInit {

  @Input() exercise: Exercise;
  @Output() goToSet = new EventEmitter<Set>();

  constructor() { }

  ngOnInit() {
  }

  goTo(set: Set) {
    this.goToSet.emit(set);
  }
}
