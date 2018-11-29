import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SessionHistoryComponent } from './session-history.component';
import { SessionHistoryRoutingModule } from './session-history-routing.module';
import { SessionHistoryHomeComponent } from './components/session-history-home/session-history-home.component';
import { NavBarModule } from '../nav-bar/nav-bar.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    SessionHistoryRoutingModule,
    NavBarModule
  ],
  declarations: [SessionHistoryComponent, SessionHistoryHomeComponent]
})
export class SessionHistoryModule { }
