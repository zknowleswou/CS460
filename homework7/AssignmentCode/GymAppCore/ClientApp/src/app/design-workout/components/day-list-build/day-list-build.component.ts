import { Component, OnInit, Input, Output, EventEmitter, Renderer2 } from '@angular/core';
import { Day } from '../../../classes/Day';
import { MatDialog } from '@angular/material';
import { NewDayDialogComponent } from '../new-day-dialog/new-day-dialog.component';
import { DesignService } from '../../../_services/design.service';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-day-list-build',
  templateUrl: './day-list-build.component.html',
  styleUrls: ['./day-list-build.component.css']
})
export class DayListBuildComponent implements OnInit {

  @Input() allDays: Day[];
  @Input() workoutId: number;
  @Output() daySet = new EventEmitter<Day>();

  days: Day[];
  deletedDays: Day[];
  activeDay: Day;
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
  }

  ngOnChanges(event) {
    this.filterDays();

  }

  filterDays(): void {
    this.deletedDays = this.allDays.filter(day => day.isDeleted);
    this.days = this.allDays.filter(day => !day.isDeleted);

    this.days.sort(function (a, b) {
      return a.order - b.order;
    });

    this.sliderLength = this.days.length;
  }

  onDayClicked(day: Day): void {
    this.daySet.emit(day);
    this.activeDay = day;
    this.sliderValue = this.activeDay.order;
  }

  getButtonColor(day: Day): string {
    if (day === this.activeDay)
      return "accent";
    return "";
  }

  rename(day: Day): void {
    this.renameId = day.dayId;

    const element = this.renderer.selectRootElement('#dayId_' + day.dayId);
    setTimeout(() => element.focus(), 0);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NewDayDialogComponent, {
      disableClose: false,
      autoFocus: true,
      closeOnNavigation: true,
      hasBackdrop: true,
      data: { workoutId: this.workoutId }
    });

    dialogRef.afterClosed().subscribe(
      day => {
        if (day) {
          this.allDays.push(day);
          this.filterDays();
          this.onDayClicked(day);
        }
      }
    );
  }

  updateDay(day: Day): void {
    this.designService.updateDay(day).subscribe(
      result => {
        if (result.isDeleted) {
          var deletedDay = this.allDays.find(x => x.dayId === day.dayId);
          deletedDay.isDeleted = result.isDeleted;
          deletedDay.order = 0;
          this.deleteDay(result);
          this.filterDays();
        }
      });
    this.renameId = 0;
  }

  deleteDay(day: Day): void {
    for (let i = day.order; i <= this.days.length; i++) {
      if (this.days.find(x => x.order === i)) {
        this.days.find(x => x.order === i).order--;
      }
    }
  }

  updateOrder(event): void {

    if (this.activeDay.order - event.value + 1 > 0) {
      for (let i = this.activeDay.order; i >= event.value; i--) {
        this.allDays.find(x => x.order === i).order++;
      }
    } else {
      for (let i = this.activeDay.order; i < event.value + 1; i++) {
        this.allDays.find(x => x.order === i).order--;
      }
    }

    this.activeDay.order = event.value;
    this.allDays.sort(function (a, b) {
      return a.order - b.order;
    });

    this.sliderDisabled = true;
    this.designService.updateDay(this.activeDay).subscribe(
      result => {
        this.sliderDisabled = false;
      });
  }

}
