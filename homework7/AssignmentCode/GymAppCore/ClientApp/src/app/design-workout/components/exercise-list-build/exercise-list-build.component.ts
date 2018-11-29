import { Component, OnInit, Input, Output, EventEmitter, OnChanges, Renderer2 } from '@angular/core';
import { Exercise } from '../../../classes/Exercise';
import { MatDialog } from '@angular/material';
import { NewExerciseDialogComponent } from '../new-exercise-dialog/new-exercise-dialog.component';
import { DesignService } from '../../../_services/design.service';

@Component({
  selector: 'app-exercise-list-build',
  templateUrl: './exercise-list-build.component.html',
  styleUrls: ['./exercise-list-build.component.css']
})
export class ExerciseListBuildComponent implements OnInit {

  @Input() allExercises: Exercise[];
  @Input() dayId: number;
  @Output() exerciseSet = new EventEmitter<Exercise>();

  exercises: Exercise[];
  deletedExercises: Exercise[];
  activeExercise: Exercise;
  sliderLength: number;
  sliderValue: number;
  sliderDisabled: boolean = false;
  renameId: number;

  constructor(
    public dialog: MatDialog,
    public designService: DesignService,
    private renderer: Renderer2
  ) { }

  ngOnInit() {
    // this.sliderLength = this.exercises.length;
  }

  ngOnChanges() {
    this.activeExercise = null;
    if (this.allExercises) {
      this.filterExercises();
    }
  }

  filterExercises(): void {
    this.deletedExercises = this.allExercises.filter(exercise => exercise.isDeleted);
    this.exercises = this.allExercises.filter(exercise => !exercise.isDeleted);
    this.sliderLength = this.exercises.length;
  }

  onExerciseClicked(exercise: Exercise): void {
    this.exerciseSet.emit(exercise);
    this.activeExercise = exercise;
    this.sliderValue = this.activeExercise.order;
  }

  getButtonColor(exercise: Exercise): string {
    if (exercise === this.activeExercise)
      return "accent";
    return "";
  }

  rename(exercise: Exercise): void {
    console.log(exercise);
    this.renameId = exercise.exerciseId;

    const element = this.renderer.selectRootElement('#exerciseId_' + exercise.exerciseId);
    setTimeout(() => element.focus(), 0);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NewExerciseDialogComponent, {
      disableClose: false,
      autoFocus: true,
      closeOnNavigation: true,
      hasBackdrop: true,
      data: { dayId: this.dayId }
    });

    dialogRef.afterClosed().subscribe(
      exercise => {
        if (exercise) {
          this.allExercises.push(exercise);
          this.filterExercises();
          this.onExerciseClicked(exercise);
        }
      }
    );
  }

  updateExercise(exercise: Exercise): void {
    this.designService.updateExercise(exercise).subscribe(
      result => {
        this.allExercises.find(x => x.exerciseId === exercise.exerciseId).isDeleted = result.isDeleted;
        this.deleteExercise(result);
        this.filterExercises();
      });
    this.renameId = 0;
  }

  deleteExercise(exercise: Exercise): void {
    for (let i = exercise.order; i <= this.exercises.length; i++) {
      if (this.exercises.find(x => x.order === i)) {
        this.exercises.find(x => x.order === i).order--;
      }
    }
  }

  updateOrder(event): void {

    if (this.activeExercise.order - event.value + 1 > 0) {
      for (let i = this.activeExercise.order; i >= event.value; i--) {
        this.exercises.find(x => x.order === i).order++;
      }
    } else {
      for (let i = this.activeExercise.order; i < event.value + 1; i++) {
        this.exercises.find(x => x.order === i).order--;
      }
    }

    this.activeExercise.order = event.value;
    this.exercises.sort(function (a, b) {
      return a.order - b.order;
    });

    this.sliderDisabled = true;
    this.designService.updateExercise(this.activeExercise).subscribe(
      result => {
        console.log(result);
        this.sliderDisabled = false;
      });
  }
}
