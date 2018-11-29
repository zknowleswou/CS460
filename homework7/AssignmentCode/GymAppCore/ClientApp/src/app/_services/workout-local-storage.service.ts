import { Injectable } from '@angular/core';
import { SessionManifestItem } from '../classes/SessionManifestItem';
import { WorkoutService } from './workout.service';
import { WorkoutSession } from '../classes/WorkoutSession';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { SetRecord } from '../classes/SetRecord';
import { SessionInfo } from '../classes/SessionInfo';

@Injectable({
  providedIn: 'root'
})
export class WorkoutLocalStorageService {
  public sessionStoreKey: string = "current_workout_session";
  public manifestStoreKey: string = "workout_sessions";
  public setRecordStoreKey: string = 'current_set_record';
  public currentSessionIdKey: string = 'current_workout_session_id';
  public sessionInfoKey: string = 'session_info';

  constructor(private workoutService: WorkoutService) { }

  getManifest(): SessionManifestItem[] {
    var sessionsString: string = localStorage.getItem(this.manifestStoreKey);
    var sessions: SessionManifestItem[] = JSON.parse(sessionsString);

    return sessions;
  }

  saveManifest(sessions: SessionManifestItem[]) {
    localStorage.setItem(this.manifestStoreKey, JSON.stringify(sessions));
  }

  reconcileManifest(): void {
    this.workoutService.getManifest().subscribe(
      //Sessions only contains incomplete workouts. If a manifest item is not present we can make it complete.
      sessions => {
        var manifest = this.getManifest();
        manifest.forEach(item => {
          var wasFound = false;
          sessions.forEach(session => {
            if (session.workoutSessionId === item.workoutSessionId) {
              wasFound = true;
            }
          });
          item.isComplete = !wasFound;
        });
        this.saveManifest(manifest);
      });
  }

  saveSession(session: WorkoutSession): void {
    localStorage.setItem(`${this.sessionStoreKey}_${session.workoutSessionId}`, JSON.stringify(session));
  }

  loadSession(workoutSessionId: number): WorkoutSession {
    var sessionString = localStorage.getItem(`${this.sessionStoreKey}_${workoutSessionId}`);
    return JSON.parse(sessionString);
  }

  completeSession(workoutSession: WorkoutSession): Observable<WorkoutSession> {
    this.saveSession(workoutSession);
    var manifest = this.getManifest();
    manifest.find(x => x.workoutSessionId === workoutSession.workoutSessionId).isComplete = true;
    workoutSession.isCompleted = true;
    this.saveManifest(manifest)
    return this.workoutService.completeSession(workoutSession);
  }

  loadSetRecord(workoutSessionId: number): SetRecord[] {
    var recordString = localStorage.getItem(`${this.setRecordStoreKey}_${workoutSessionId}`);
    return JSON.parse(recordString);
  }

  saveSetRecord(workoutSessionId: number, records: SetRecord[]): void {
    console.log(`${this.setRecordStoreKey}_${workoutSessionId}`);
    console.log(records);
    localStorage.setItem(`${this.setRecordStoreKey}_${workoutSessionId}`, JSON.stringify(records));
  }

  setCurrentSessionId(workoutSessionId: number) {
    if (workoutSessionId) {
      localStorage.setItem(this.currentSessionIdKey, `${workoutSessionId}`);
    } else {
      localStorage.removeItem(this.currentSessionIdKey);
    }
  }

  setSessionInfo(session: SessionInfo) {
    localStorage.setItem(`${this.sessionInfoKey}_${session.workoutSessionId}`, JSON.stringify(session));
  }

  getSessionInfo(sessionId: number): SessionInfo {
    var sessionString = localStorage.getItem(`${this.sessionInfoKey}_${sessionId}`)
    return JSON.parse(sessionString);
  }

  getCurrentSessionId(): number {
    return +localStorage.getItem(this.currentSessionIdKey);
  }

  createSession(dayId: number): Observable<WorkoutSession> {
    return this.workoutService.startSession(dayId)
      .pipe(
        tap(session => {
          var manifest = this.getManifest();
          manifest = manifest ? manifest : [];
          var item = new SessionManifestItem(session.workoutSessionId, session.dayId)
          manifest.push(item)
          this.saveManifest(manifest);
          this.saveSession(session);
        })
      );
  }
}
