import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NewExerciseDialogComponent } from '../new-exercise-dialog/new-exercise-dialog.component';
import { DesignService } from '../../../_services/design.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Set } from '../../../classes/Set';

@Component({
  selector: 'app-new-set-dialog',
  templateUrl: './new-set-dialog.component.html',
  styleUrls: ['./new-set-dialog.component.css']
})
export class NewSetDialogComponent implements OnInit {

creatingSet: boolean;
exerciseId: number;

  constructor(
    private dialogRef: MatDialogRef<NewExerciseDialogComponent>,
    private designService: DesignService,
    @Inject(MAT_DIALOG_DATA) data
  ) { 
    this.exerciseId = data.exerciseId
  }

  newSetForm = new FormGroup({
    'setName': new FormControl('', [Validators.required])
  });

  ngOnInit() {
  }

  createSet(): void {
    this.creatingSet = true;
    var set = new Set(this.newSetForm.value.setName, this.exerciseId);
    this.designService.createSet(set)
      .subscribe(
        result => {
          this.dialogRef.close(result);
          this.creatingSet = false;
        });
  }

}
