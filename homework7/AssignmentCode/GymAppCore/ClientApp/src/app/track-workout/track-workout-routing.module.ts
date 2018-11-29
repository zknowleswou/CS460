import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TrackWorkoutComponent } from './track-workout.component';
import { AuthGuard } from '../auth.guard';
import { RecordWorkoutComponent } from './components/record-workout/record-workout.component';
import { WorkoutListComponent } from './components/workout-list/workout-list.component';
import { WorkoutDetailComponent } from './components/workout-detail/workout-detail.component';
import { DayComponent } from './components/day/day.component';
import { SessionSummaryComponent } from '../info/session-summary/session-summary.component';
import { TrackSessionComponent } from './components/track-session/track-session.component';

const trackRoutes: Routes = [
  {
    path: 'track',
    component: TrackWorkoutComponent,
    children: [
      {
        path: '',
        component: RecordWorkoutComponent,
        canActivate: [AuthGuard],
        children: [
          { path: '', component: WorkoutListComponent },
          { path: ':id', component: WorkoutDetailComponent },
          { path: ':workoutId/day/:dayId', component: DayComponent },
          { path: 'session/:dayId', component: TrackSessionComponent }
        ]
      },
      {
        path: 'info/summary/:workoutSessionId',
        component: SessionSummaryComponent
      },
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(trackRoutes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class TrackWorkoutRoutingModule { }
