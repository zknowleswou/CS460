import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DesignService } from '../../../_services/design.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Exercise } from '../../../classes/Exercise';

@Component({
  selector: 'app-new-exercise-dialog',
  templateUrl: './new-exercise-dialog.component.html',
  styleUrls: ['./new-exercise-dialog.component.css']
})
export class NewExerciseDialogComponent implements OnInit {

  creatingExercise: boolean;
  dayId: number;

  constructor(
    private dialogRef: MatDialogRef<NewExerciseDialogComponent>,
    private designService: DesignService,
    @Inject(MAT_DIALOG_DATA) data
  ) {
    this.dayId = data.dayId;
  }

  newExerciseForm = new FormGroup({
    'exerciseName': new FormControl('', [Validators.required])
  });

  ngOnInit() {
  }

  createExercise():void{
    this.creatingExercise = true;
    var exercise = new Exercise(this.newExerciseForm.value.exerciseName, this.dayId);
    this.designService.createExercise(exercise).subscribe(
      result => {
        this.dialogRef.close(result);
        this.creatingExercise = false;
      }
    )
  }
}
