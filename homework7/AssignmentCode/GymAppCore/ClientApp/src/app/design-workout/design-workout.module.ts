import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DesignWorkoutComponent } from './design-workout.component';
import { DesignWorkoutRoutingModule } from './design-workout-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialImportModule } from '../material-import/material-import.module';
import { WorkoutCardComponent } from './components/workout-card/workout-card.component';
import { DesignHomeComponent } from './components/design-home/design-home.component';
import { NewWorkoutDialogComponent } from './components/new-workout-dialog/new-workout-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BuilderComponent } from './components/builder/builder.component';
import { DayCardComponent } from './components/day-card/day-card.component';
import { DayListBuildComponent } from './components/day-list-build/day-list-build.component';
import { NewDayDialogComponent } from './components/new-day-dialog/new-day-dialog.component';
import { ExerciseListBuildComponent } from './components/exercise-list-build/exercise-list-build.component';
import { NewExerciseDialogComponent } from './components/new-exercise-dialog/new-exercise-dialog.component';
import { NewSetDialogComponent } from './components/new-set-dialog/new-set-dialog.component';
import { SetListBuildComponent } from './components/set-list-build/set-list-build.component';
import { SetDetailsBuildComponent } from './components/set-details-build/set-details-build.component';

@NgModule({
  imports: [
    CommonModule,
    DesignWorkoutRoutingModule,
    BrowserAnimationsModule,
    MaterialImportModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [

  ],
  declarations: [DesignWorkoutComponent, WorkoutCardComponent, DesignHomeComponent, NewWorkoutDialogComponent, BuilderComponent, DayCardComponent, DayListBuildComponent, NewDayDialogComponent, ExerciseListBuildComponent, NewExerciseDialogComponent, NewSetDialogComponent, SetListBuildComponent, SetDetailsBuildComponent],
  entryComponents: [
    NewWorkoutDialogComponent,
    NewDayDialogComponent,
    NewExerciseDialogComponent,
    NewSetDialogComponent
  ]
})
export class DesignWorkoutModule { }
