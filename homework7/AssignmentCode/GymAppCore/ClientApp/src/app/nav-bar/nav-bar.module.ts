import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule, Router } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    RouterModule
  ],
  exports:[
    NavBarComponent
  ],
  declarations: [
    NavBarComponent
  ]
})
export class NavBarModule { }
