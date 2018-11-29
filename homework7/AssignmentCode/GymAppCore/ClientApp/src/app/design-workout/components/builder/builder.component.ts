import { Component, OnInit, Renderer2 } from '@angular/core';
import { WorkoutService } from '../../../_services/workout.service';
import { DesignService } from '../../../_services/design.service';
import { ActivatedRoute } from '@angular/router';
import { Workout } from '../../../classes/Workout';
import { Day } from '../../../classes/Day';
import { Exercise } from '../../../classes/Exercise';
import { Set } from '../../../classes/Set';

@Component({
  selector: 'app-builder',
  templateUrl: './builder.component.html',
  styleUrls: ['./builder.component.css']
})
export class BuilderComponent implements OnInit {

  workout: Workout;
  activeDay: Day;
  activeExercise: Exercise;
  activeSet: Set;
  renaming: boolean = false;

  constructor(
    private workoutService: WorkoutService,
    private designService: DesignService,
    private route: ActivatedRoute,
    public renderer: Renderer2
  ) { }

  ngOnInit() {
    let workoutId: number = +this.route.snapshot.paramMap.get("workoutId");
    this.workoutService.getWorkout(workoutId).subscribe(
      workout => this.workout = workout
    )
  }

  setActiveDay(day: Day): void {
    this.activeDay = day;
    this.activeExercise = null;
    this.activeSet = null;
  }

  setActiveExercise(exercise: Exercise): void {
    this.activeExercise = exercise;
    this.activeSet = null;
  }

  setActiveSet(set: Set): void {
    this.activeSet = set;
  }

  rename(): void {
    this.renaming = true;
    const element = this.renderer.selectRootElement('#workoutName');
    setTimeout(() => element.focus(), 0);
  }

  updateWorkout(): void {
    this.designService.updateWorkout(this.workout).subscribe(
      result => {
      }
    )
    this.renaming = false;
  }

  applyToAllSets(set: Set) {
    this.activeExercise.sets.forEach(setToUpdate => {
      if (setToUpdate.setId != set.setId) {
        setToUpdate.repititions = set.repititions;
        setToUpdate.weight = set.weight;
        this.designService.updateSet(setToUpdate);
      }
    });
  }
}
