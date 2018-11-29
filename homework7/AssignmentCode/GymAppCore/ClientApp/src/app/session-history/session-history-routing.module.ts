import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { SessionHistoryComponent } from './session-history.component';
import { SessionHistoryHomeComponent } from './components/session-history-home/session-history-home.component';
import { NavBarModule } from '../nav-bar/nav-bar.module';

const historyRoutes: Routes = [
  {
    path: 'history',
    component: SessionHistoryComponent,
    children: [
      {
        path: '',
        component: SessionHistoryHomeComponent
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(historyRoutes),
    NavBarModule
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class SessionHistoryRoutingModule { }
