import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RecordWorkoutComponent } from './components/record-workout/record-workout.component';
import { WorkoutListComponent } from './components/workout-list/workout-list.component';
import { DayComponent } from './components/day/day.component';
import { FinishSessionComponent } from './components/finish-session/finish-session.component';
import { WorkoutDetailComponent } from './components/workout-detail/workout-detail.component';
import { TrackSessionComponent } from './components/track-session/track-session.component';
import { SetTimerComponent } from './components/set-timer/set-timer.component';
import { TrackSetComponent } from './components/track-set/track-set.component';
import { TrackWorkoutRoutingModule } from './track-workout-routing.module';
import { TrackWorkoutComponent } from './track-workout.component';
import { NavBarModule } from '../nav-bar/nav-bar.module';
import { QuickNavComponent } from './components/quick-nav/quick-nav.component';
import { QuickNavButtonComponent } from './components/quick-nav-button/quick-nav-button.component';



@NgModule({
  imports: [
    TrackWorkoutRoutingModule,
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NavBarModule
  ],
  declarations: [
    RecordWorkoutComponent,
    WorkoutListComponent,
    DayComponent,
    FinishSessionComponent,
    WorkoutDetailComponent,
    TrackSessionComponent,
    SetTimerComponent,
    TrackSetComponent,
    TrackWorkoutComponent,
    QuickNavComponent,
    QuickNavButtonComponent
  ]
})
export class TrackWorkoutModule { }
