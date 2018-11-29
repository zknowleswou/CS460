import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkoutService } from '../../../_services/workout.service';
import { Workout } from '../../../classes/Workout';
import { Day } from 'src/app/classes/Day';
import { WorkoutSession } from 'src/app/classes/WorkoutSession';
import { WorkoutLocalStorageService } from 'src/app/_services/workout-local-storage.service';

@Component({
  selector: 'app-workout-detail',
  templateUrl: './workout-detail.component.html',
  styleUrls: ['./workout-detail.component.css']
})
export class WorkoutDetailComponent implements OnInit {

  workout: Workout;
  isLoaded: boolean;
  days: Day[];
  deletedDays: Day[];
  incompleteSession: WorkoutSession;


  constructor(
    private route: ActivatedRoute,
    private workoutService: WorkoutService,
    private workoutStorage: WorkoutLocalStorageService
  ) { }

  ngOnInit() {
    console.log("workout detail");
    this.isLoaded = false;
    const workoutId: number = +this.route.snapshot.paramMap.get('id');
    this.workoutService.getWorkoutForSession(workoutId).subscribe(
      workout => {
        this.workout = workout;
        var sessionManifest = this.workoutStorage.getManifest();
        this.workout.days.forEach(day => {
          if (sessionManifest && sessionManifest.find(item => item.dayId === day.dayId && !item.isComplete))
            day.hasIncompleteSession = true;
        });
        this.isLoaded = true;
      });
  }
}
