import { Exercise } from './Exercise';

export class Day {
  name: string;
  dayId: number;
  workoutId: number;
  order: number;
  isRestDay: boolean;
  exercises: Exercise[];
  isDeleted: boolean;

    //Client Side Properties
    hasIncompleteSession: boolean;

  constructor(name: string, workoutId: number) {
    this.name = name;
    this.workoutId = workoutId;
    
    this.hasIncompleteSession = false;
  }
}
