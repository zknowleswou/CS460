import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';


import { WorkoutService } from '../../../_services/workout.service';
import { Workout } from '../../../classes/Workout';

@Component({
  selector: 'app-workout-list',
  templateUrl: './workout-list.component.html',
  styleUrls: ['./workout-list.component.css']
})
export class WorkoutListComponent implements OnInit {

  workouts: Workout[];
  id: number;

  constructor(
    private workoutService: WorkoutService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.workoutService.getWorkouts().subscribe(
      workouts => this.workouts = workouts
    );
    this.id = +this.route.snapshot.paramMap.get('id');
  }

}
