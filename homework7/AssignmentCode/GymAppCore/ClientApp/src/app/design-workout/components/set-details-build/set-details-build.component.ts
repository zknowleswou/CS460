import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { Set } from '../../../classes/Set';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DesignService } from 'src/app/_services/design.service';

@Component({
  selector: 'app-set-details-build',
  templateUrl: './set-details-build.component.html',
  styleUrls: ['./set-details-build.component.css']
})
export class SetDetailsBuildComponent implements OnInit {

  @Input() set: Set;
  @Output() applyAllClicked = new EventEmitter<Set>();

  constructor(
    private designService: DesignService,

  ) { }

  updateSetForm = new FormGroup({
    'weight': new FormControl('', [Validators.required]),
    'repititions': new FormControl('', [Validators.required])
  });


  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
    this.updateSetForm.setValue({
      weight: changes.set.currentValue.weight,
      repititions: changes.set.currentValue.repititions
    });
  }

  updateSet(): void {
    this.set.weight = this.updateSetForm.value.weight;
    this.set.repititions = this.updateSetForm.value.repititions;

    this.designService.updateSet(this.set).subscribe(
      result => {
        this.updateSetForm.markAsPristine();
      });
  }

  applyAll(){
    this.updateSet();
    this.applyAllClicked.emit(this.set);
  }
}
