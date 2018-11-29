import { Component, OnInit, Input, Output, EventEmitter, OnChanges, Renderer2 } from '@angular/core';
import { Set } from '../../../classes/Set';
import { MatDialog } from '@angular/material';
import { NewSetDialogComponent } from 'src/app/design-workout/components/new-set-dialog/new-set-dialog.component';
import { DesignService } from '../../../_services/design.service';

@Component({
  selector: 'app-set-list-build',
  templateUrl: './set-list-build.component.html',
  styleUrls: ['./set-list-build.component.css']
})
export class SetListBuildComponent implements OnInit {

  @Input() allSets: Set[];
  @Input() exerciseId: number;
  @Output() currentSetSet = new EventEmitter<Set>();

  sets: Set[];
  deletedSets: Set[];
  activeSet: Set;
  sliderLength: number;
  sliderValue: number;
  sliderDisabled: boolean = false;
  renameId: number;

  constructor(
    public dialog: MatDialog,
    public designService: DesignService,
    public renderer: Renderer2
  ) { }

  ngOnInit() {
    this.sliderLength = this.sets.length;
  }

  ngOnChanges(event) {
    if (this.allSets)
      this.filterSets();
      
    this.activeSet = null;
  }

  filterSets() {
    this.deletedSets = this.allSets.filter(set => set.isDeleted);
    this.sets = this.allSets.filter(set => !set.isDeleted);
    this.sliderLength = this.sets.length;
  }

  onSetClicked(set: Set): void {
    this.currentSetSet.emit(set);
    this.activeSet = set;
    this.sliderValue = this.activeSet.order;
  }

  getButtonColor(set: Set): string {
    if (set === this.activeSet)
      return "accent";
    return "";
  }

  rename(set: Set): void {
    this.renameId = set.setId;

    const element = this.renderer.selectRootElement('#setId_' + set.setId);
    setTimeout(() => element.focus(), 0);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NewSetDialogComponent, {
      disableClose: false,
      autoFocus: true,
      closeOnNavigation: true,
      hasBackdrop: true,
      data: { exerciseId: this.exerciseId }
    });

    dialogRef.afterClosed().subscribe(
      set => {
        if (set) {
          this.allSets.push(set);
          this.filterSets();
        }
      }
    );
  }

  updateSet(set: Set): void {
    this.designService.updateSet(set).subscribe(
      result => {
        if (result.isDeleted) {
          this.allSets.find(x => x.setId === set.setId).isDeleted = result.isDeleted;
          this.deleteSet(result);
          this.filterSets();
        }
      });
    this.renameId = 0;
  }

  deleteSet(set: Set): void {
    for (let i = set.order; i <= this.sets.length; i++) {
      if (this.sets.find(x => x.order === i)) {
        this.sets.find(x => x.order === i).order--;
      }
    }
  }

  updateOrder(event): void {

    if (this.activeSet.order - event.value + 1 > 0) {
      for (let i = this.activeSet.order; i >= event.value; i--) {
        this.sets.find(x => x.order === i).order++;
      }
    } else {
      for (let i = this.activeSet.order; i < event.value + 1; i++) {
        this.sets.find(x => x.order === i).order--;
      }
    }

    this.activeSet.order = event.value;
    this.sets.sort(function (a, b) {
      return a.order - b.order;
    });

    this.sliderDisabled = true;
    this.designService.updateSet(this.activeSet).subscribe(
      result => {
        this.sliderDisabled = false;
      });
  }
}
