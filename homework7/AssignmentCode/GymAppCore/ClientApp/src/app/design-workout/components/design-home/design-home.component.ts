import { Component, OnInit } from '@angular/core';
import { Workout } from '../../../classes/Workout';
import { WorkoutService } from '../../../_services/workout.service';
import { MatDialog } from '@angular/material';
import { NewWorkoutDialogComponent } from '../new-workout-dialog/new-workout-dialog.component';

@Component({
  selector: 'app-design-home',
  templateUrl: './design-home.component.html',
  styleUrls: ['./design-home.component.css']
})
export class DesignHomeComponent implements OnInit {

  workouts: Workout[] = [];

  constructor(
    private workoutService: WorkoutService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.workoutService.getWorkouts().subscribe(
      workouts => this.workouts = workouts
    )
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NewWorkoutDialogComponent, {
      disableClose: false,
      autoFocus: true,
      closeOnNavigation: true,
      hasBackdrop: true
    });
  }
}
