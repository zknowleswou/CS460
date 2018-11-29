import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { WorkoutSession } from '../../../classes/WorkoutSession';
import { Router } from '@angular/router';
import { WorkoutLocalStorageService } from 'src/app/_services/workout-local-storage.service';

@Component({
  selector: 'app-finish-session',
  templateUrl: './finish-session.component.html',
  styleUrls: ['./finish-session.component.css']
})
export class FinishSessionComponent implements OnInit {

  @Output() returnToCards = new EventEmitter();
  @Input() workoutSession: WorkoutSession;
  constructor(
    private router: Router,
    private workoutStorage: WorkoutLocalStorageService
  ) { }

  ngOnInit() {
  }

  goBack(): void {
    this.returnToCards.emit(null);
  }

  completeWorkout() {
    this.workoutSession.isCompleted = true;
    this.workoutStorage.completeSession(this.workoutSession)
      .subscribe(
        result => this.router.navigate([`track/info/summary/${this.workoutSession.workoutSessionId}`])
      );
  }
}
