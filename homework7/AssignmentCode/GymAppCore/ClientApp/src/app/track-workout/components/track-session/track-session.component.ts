import { Component, OnInit } from '@angular/core';
import { WorkoutService } from '../../../_services/workout.service';
import { Day } from 'src/app/classes/Day';
import { Exercise } from 'src/app/classes/Exercise';
import { Set } from 'src/app/classes/Set';
import { ActivatedRoute } from '@angular/router';
import { SetRecord } from '../../../classes/SetRecord';
import { WorkoutSession } from '../../../classes/WorkoutSession';
import { WorkoutLocalStorageService } from 'src/app/_services/workout-local-storage.service';
import { SessionInfo } from 'src/app/classes/SessionInfo';


@Component({
  selector: 'app-track-session',
  templateUrl: './track-session.component.html',
  styleUrls: ['./track-session.component.css']
})
export class TrackSessionComponent implements OnInit {

  dayId: number;
  day: Day;
  currentExercise: Exercise;
  currentSet: Set;
  currentSetRecord: SetRecord;
  workoutRecord: SetRecord[];
  workoutSession: WorkoutSession;
  showFinishWorkout: boolean;

  constructor(
    private workoutService: WorkoutService,
    private route: ActivatedRoute,
    private workoutStorage: WorkoutLocalStorageService
  ) { }

  ngOnInit() {
    this.dayId = +this.route.snapshot.paramMap.get("dayId");
    this.workoutRecord = [];

    var sessionId = this.workoutStorage.getCurrentSessionId();

    if (sessionId) {
      this.workoutSession = this.workoutStorage.loadSession(sessionId);
      console.log(this.workoutSession);
      this.initializeSetRecordStore();
      this.loadDay();
    } else {
      this.startNewSession(this.dayId);
    }
  }

  startNewSession(dayId: number): void {
    this.workoutStorage.createSession(dayId)
      .subscribe(
        session => {
          this.workoutSession = session;
          this.initializeSetRecordStore();
          this.loadDay();
          this.workoutStorage.setCurrentSessionId(this.workoutSession.workoutSessionId);
        }
      );
  }

  loadDay() {
    this.workoutService.getDay(this.dayId)
      .subscribe(day => {
        this.day = day;
        var sessionInfo = this.workoutStorage.getSessionInfo(this.workoutSession.workoutSessionId);
        if (sessionInfo) {
          this.currentExercise = this.day.exercises[sessionInfo.exerciseIndex];
          this.initializeSetRecord(this.day.exercises[sessionInfo.exerciseIndex].sets[sessionInfo.setIndex]);
        } else {
          this.currentExercise = this.day.exercises[0];
          this.initializeSetRecord(this.day.exercises[0].sets[0]);
        }
      });
  }

  initializeSetRecord(set: Set) {
    this.currentSet = set;
    var existingSetRecord = this.workoutRecord.find(set => set.setId === this.currentSet.setId);
    if (!existingSetRecord) {
      let setRecord = new SetRecord(set, this.workoutSession.workoutSessionId);
      this.currentSetRecord = setRecord;
      this.workoutRecord.push(this.currentSetRecord);
      this.workoutStorage.saveSetRecord(this.workoutSession.workoutSessionId, this.workoutRecord);
    } else {
      this.currentSetRecord = existingSetRecord;
    }

  }

  saveSetRecord(setRecord: SetRecord) {
    this.workoutService.saveSetRecord(setRecord).subscribe(
      savedSetRecord => this.updateSetRecord(savedSetRecord)
    );
  }

  private initializeSetRecordStore(): void {
    var existingSetRecord: SetRecord[] = this.workoutStorage.loadSetRecord(this.workoutSession.workoutSessionId);

    if (existingSetRecord) {
      this.workoutRecord = existingSetRecord;
    } else {
      this.workoutRecord = [];
    }
  }

  updateSetRecord(setRecord: SetRecord) {
    this.workoutRecord.find(record => record.setId == setRecord.setId).setRecordId = setRecord.setRecordId;
    this.workoutStorage.saveSetRecord(this.workoutSession.workoutSessionId, this.workoutRecord);
    console.log(this.workoutRecord);
  }

  skipExercise() {
    // let currentExercise = getCurrentExerciseIndex();

  }

  saveWorkoutInfo() {
    let currentExerciseIndex = this.getCurrentExerciseIndex();
    let currentSetIndex = this.getCurrentSetIndex();

    var sessionInfo = new SessionInfo(currentExerciseIndex, currentSetIndex, this.workoutSession.workoutSessionId);
    this.workoutStorage.setSessionInfo(sessionInfo);
  }

  nextSet() {
    let currentExerciseIndex = this.getCurrentExerciseIndex();
    let currentSetIndex = this.getCurrentSetIndex();


    if (currentSetIndex + 1 < this.currentExercise.sets.length) {
      //There are more sets to do
      this.goToSet(this.currentExercise.sets[currentSetIndex + 1])
    } else if (currentExerciseIndex + 1 < this.day.exercises.length) {
      //We are on the last set but there are more exercises
      this.currentExercise = this.day.exercises[currentExerciseIndex + 1];
      this.goToSet(this.currentExercise.sets[0]);
    } else {
      //We are done with the workout
      this.showFinishWorkout = true;
    }
  }

  previousSet() {
    let currentExerciseIndex = this.getCurrentExerciseIndex();
    let currentSetIndex = this.getCurrentSetIndex();

    if (this.showFinishWorkout) {
      this.showFinishWorkout = false;
    } else if (currentSetIndex !== 0) {
      //We can go back a set
      this.goToSet(this.currentExercise.sets[currentSetIndex - 1])
    } else if (currentExerciseIndex !== 0) {
      //We need to go back a whole exercise
      this.currentExercise = this.day.exercises[currentExerciseIndex - 1];
      this.goToSet(this.currentExercise.sets[this.currentExercise.sets.length - 1])
    } else {
      //We are at the beginning
    }
  }

  private getCurrentExerciseIndex(): number {
    return this.day.exercises.findIndex(exercise => exercise.exerciseId === this.currentExercise.exerciseId);
  }

  private getCurrentSetIndex(): number {
    return this.currentExercise.sets.findIndex(set => set.setId == this.currentSetRecord.setId);
  }

  goToSet(set: Set): void {
    this.saveSetRecord(this.currentSetRecord);
    var exerciseIndex = this.day.exercises.findIndex(e => e.exerciseId === set.exerciseId);
  
    this.currentExercise = this.day.exercises[exerciseIndex];
    var setIndex = this.currentExercise.sets.findIndex(e=> e.setId === set.setId);

    this.initializeSetRecord(this.currentExercise.sets[setIndex]);
    this.saveWorkoutInfo();
  }

}
