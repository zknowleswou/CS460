import { Injectable } from '@angular/core';
import { Workout } from '../classes/Workout';
import { Day } from '../classes/Day';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SetRecord } from '../classes/SetRecord';
import { WorkoutSession } from '../classes/WorkoutSession';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
  providedIn: 'root'
})
export class WorkoutService {
  constructor(
    private http: HttpClient
  ) { }

  public sessionStoreKey:string  = "current_workout_session";
  public setRecordStoreKey: string = 'current_set_record';

  private workoutUrl = 'api/workout';
  private dayUrl = 'api/day';
  private setRecordUrl = 'api/setrecord';
  private workoutSessionUrl = 'api/workoutsession';

  getWorkouts(): Observable<Workout[]> {
    return this.http.get<Workout[]>(this.workoutUrl);

  }

  getWorkout(workoutId: number): Observable<Workout> {
    return this.http.get<Workout>(`${this.workoutUrl}/${workoutId}`);
  }

  getWorkoutForSession(workoutId: number): Observable<Workout>{
    return this.http.get<Workout>(`${this.workoutUrl}/${workoutId}/active`);
  }

  getDay(dayId: number): Observable<Day> {
    return this.http.get<Day>(`${this.dayUrl}/${dayId}`);
  }

  getManifest():Observable<WorkoutSession[]>{
    return this.http.get<WorkoutSession[]>(`${this.workoutSessionUrl}/manifest`);
  }

  saveSetRecord(setRecord: SetRecord): Observable<SetRecord> {
    return this.http.post<SetRecord>(this.setRecordUrl, setRecord, httpOptions);
  }

  startSession(dayId: number): Observable<WorkoutSession>{
    return this.http.post<WorkoutSession>(`${this.workoutSessionUrl}/${dayId}`, null, httpOptions);
  }

  completeSession(workoutSession: WorkoutSession):Observable<WorkoutSession>{
    return this.http.put<WorkoutSession>(`${this.workoutSessionUrl}`, workoutSession, httpOptions);
  }
}
