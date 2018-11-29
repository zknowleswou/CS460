import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Workout } from '../classes/Workout';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Day } from '../classes/Day';
import { Exercise } from 'src/app/classes/Exercise';
import { Set } from '../classes/Set';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class DesignService {


  private workoutApi: string = "api/workout"
  private dayApi: string = "api/day";
  private exerciseApi: string = "api/exercise";
  private setApi: string = "api/set";

  constructor(
    private http: HttpClient
  ) { }

  public createWorkout(name: string): Observable<Workout> {
    var workout = new Workout(name);
    return this.http.post<Workout>(this.workoutApi, workout, httpOptions)
  }

  public updateWorkout(workout: Workout): Observable<Workout>{
    return this.http.put<Workout>(this.workoutApi, workout, httpOptions);
  }

  public createDay(day: Day): Observable<Day> {
    return this.http.post<Day>(this.dayApi, day, httpOptions);
  }

  public updateDay(day: Day): Observable<Day> {
    return this.http.put<Day>(this.dayApi, day, httpOptions);
  }

  public createExercise(exercise: Exercise): Observable<Exercise> {
    return this.http.post<Exercise>(this.exerciseApi, exercise, httpOptions);
  }

  public updateExercise(exercise:Exercise): Observable<Exercise>{
    return this.http.put<Exercise>(this.exerciseApi, exercise, httpOptions);
  }

  public createSet(set: Set): Observable<Set> {
    return this.http.post<Set>(this.setApi, set, httpOptions);
  }

  public updateSet(set: Set): Observable<Set> {
    return this.http.put<Set>(this.setApi, set, httpOptions);
  }
}
