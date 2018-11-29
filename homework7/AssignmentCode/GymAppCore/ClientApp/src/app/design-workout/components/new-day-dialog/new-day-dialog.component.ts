import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DesignService } from '../../../_services/design.service';
import { Day } from '../../../classes/Day';

@Component({
  selector: 'app-new-day-dialog',
  templateUrl: './new-day-dialog.component.html',
  styleUrls: ['./new-day-dialog.component.css']
})
export class NewDayDialogComponent implements OnInit {

  workoutId: number;
  creatingDay: boolean;

  constructor(
    private dialogRef: MatDialogRef<NewDayDialogComponent>,
    private designService: DesignService,
    @Inject(MAT_DIALOG_DATA) data
  ) {
    this.workoutId = data.workoutId;
  }

  newDayForm = new FormGroup({
    'dayName': new FormControl('', [Validators.required])
  });

  ngOnInit() {
  }

  createDay(): void {
    this.creatingDay = true;
    var day = new Day(this.newDayForm.value.dayName, this.workoutId);
    this.designService.createDay(day)
      .subscribe(
        result => {
          this.dialogRef.close(result);
          this.creatingDay = false;
        });
  }
}
