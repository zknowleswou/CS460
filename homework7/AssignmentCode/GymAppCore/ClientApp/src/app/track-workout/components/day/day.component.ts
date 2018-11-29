import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkoutService } from '../../../_services/workout.service';
import { Workout } from '../../../classes/Workout';
import { Day } from '../../../classes/Day';
import { WorkoutSession } from '../../../classes/WorkoutSession';
import { WorkoutLocalStorageService } from 'src/app/_services/workout-local-storage.service';
import { SessionManifestItem } from 'src/app/classes/SessionManifestItem';

@Component({
  selector: 'app-day',
  templateUrl: './day.component.html',
  styleUrls: ['./day.component.css']
})
export class DayComponent implements OnInit {

  dayId: number;
  workoutId: number;
  workout: Workout;
  day: Day;
  workoutSession: WorkoutSession;
  incompleteSessions: SessionManifestItem[];

  constructor(
    private route: ActivatedRoute,
    private workoutService: WorkoutService,
    private workoutStorage: WorkoutLocalStorageService
  ) { }

  ngOnInit() {

    this.workoutId = +this.route.snapshot.paramMap.get('workoutId');
    this.dayId = +this.route.snapshot.paramMap.get('dayId');

    this.workoutService.getWorkoutForSession(this.workoutId)
      .subscribe(
        workout => this.loadWorkoutAndDay(workout)
      );
  }

  private loadWorkoutAndDay(workout: Workout) {

    this.workout = workout;
    this.day = this.workout.days.find(day => day.dayId === this.dayId)
    var manifest = this.workoutStorage.getManifest();
    this.incompleteSessions = [];
    if (manifest) {
      manifest.forEach(item => {
        if (!item.isComplete)
          this.incompleteSessions.push(item);
      })
    }
  }

  clearCurrentSession() {
    this.workoutStorage.setCurrentSessionId(null);
  }

  setCurrentSession(item: SessionManifestItem) {
    if (item) { this.workoutStorage.setCurrentSessionId(item.workoutSessionId); }
    else {
      this.workoutStorage.setCurrentSessionId(this.incompleteSessions[0].workoutSessionId);
    }
  }
}
