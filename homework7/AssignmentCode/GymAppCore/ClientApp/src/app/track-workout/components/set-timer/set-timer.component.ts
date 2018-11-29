import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { timer } from 'rxjs';
import { SetRecord } from '../../../classes/SetRecord';

@Component({
  selector: 'app-set-timer',
  templateUrl: './set-timer.component.html',
  styleUrls: ['./set-timer.component.css']
})
export class SetTimerComponent implements OnInit {
  @Input() setRecord: SetRecord;

  duration: number;
  timerProgress: number;
  isTimerVisible: boolean;
  restTimeSeconds: number;
  startTime: Date;
  roundedDuration: Number;

  constructor() { }

  ngOnInit() {
    this.restTimeSeconds = 120;
    this.duration = 0;
    this.isTimerVisible = false;
  }

  ngOnChanges() {
    this.restTimeSeconds = 120;
    this.duration = 0;
    this.isTimerVisible = false;
  }

  startRest() {
    if (this.timerProgress !== 100 && this.duration !== 0)
      return;

    this.startTime = new Date();

    this.isTimerVisible = true;
    var test = timer(100);
    test.subscribe(x => {
      this.rest();
    });
  }

  rest() {
    let currentTime: Date = new Date();

    var dif = this.startTime.getTime() - currentTime.getTime();

    var Seconds_from_T1_to_T2 = dif / 1000;
    this.duration = Math.abs(Seconds_from_T1_to_T2);

    this.timerProgress = (this.duration / this.restTimeSeconds) * 100;

    if (this.restTimeSeconds > this.duration) {
      this.roundedDuration = Math.round(this.duration);
      var test = timer(500);
      test.subscribe(x => {
        if (this.isTimerVisible)
          this.rest();
      });
    } else {
      this.roundedDuration = 120;
      this.timerProgress = 100;
    }
  }

}
