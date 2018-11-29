import { Component, OnInit } from '@angular/core';
import { WorkoutLocalStorageService } from '../_services/workout-local-storage.service';

@Component({
  selector: 'app-track-workout',
  templateUrl: './track-workout.component.html',
  styleUrls: ['./track-workout.component.css']
})
export class TrackWorkoutComponent implements OnInit {

  constructor(
    private workoutStorage : WorkoutLocalStorageService
  ) { }

  ngOnInit() {
    this.workoutStorage.reconcileManifest();
  }

}
