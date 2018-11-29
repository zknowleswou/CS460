import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { DesignService } from '../../../_services/design.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-workout-dialog',
  templateUrl: './new-workout-dialog.component.html',
  styleUrls: ['./new-workout-dialog.component.css']
})
export class NewWorkoutDialogComponent implements OnInit {

  creatingWorkout: boolean = false;
  workoutName: string;

  constructor(
    public dialogRef: MatDialogRef<NewWorkoutDialogComponent>,
    private designService: DesignService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  createWorkout(): void {
    this.creatingWorkout = true;
    console.log(this.workoutName);
    this.designService.createWorkout(this.workoutName).subscribe(
      workout => {
        this.router.navigate([`design/${workout.workoutId}`]);
        this.dialogRef.close();
      }
    )
  }
}
