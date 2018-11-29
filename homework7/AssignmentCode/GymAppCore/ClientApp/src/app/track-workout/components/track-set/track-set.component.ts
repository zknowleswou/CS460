import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { SetRecord } from '../../../classes/SetRecord';
import { Renderer2 } from '@angular/core';

@Component({
  selector: 'app-track-set',
  templateUrl: './track-set.component.html',
  styleUrls: ['./track-set.component.css']
})
export class TrackSetComponent implements OnInit {
  @Input() setRecord: SetRecord;

  showRepsBox: boolean = false;
  showWeightBox: boolean = false;

  constructor(
    private renderer: Renderer2
  ) { }

  ngOnInit() {

  }

  ngOnChanges() {

  }

  repUp() {
    this.setRecord.completedRepititions++;
  }

  repDown() {
    this.setRecord.completedRepititions--;
  }

  weightUp() {
    this.setRecord.completedWeight += 0.5;
  }

  weightDown() {
    this.setRecord.completedWeight -= 0.5;
  }

  showRepsChangeBox(): void {
    this.showRepsBox = true;
    const element = this.renderer.selectRootElement('#completedReps');
    setTimeout(() => element.focus(), 0);
  }

  hideRepsChangeBox(): void {
    this.showRepsBox = false;
    this.setRecord.completedRepititions = Math.round(this.setRecord.completedRepititions);
  }

  showWeightChangeBox(): void {
    this.showWeightBox = true;
    const element = this.renderer.selectRootElement('#completedWeight');
    setTimeout(() => element.focus(), 0);
  }

  hideWeightChangeBox(): void {
    this.showWeightBox = false;
  }
}
