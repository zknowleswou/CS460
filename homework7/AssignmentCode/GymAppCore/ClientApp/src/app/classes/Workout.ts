import { Day } from './Day';

export class Workout {
  name: string;
  workoutId: number;
  days: Day[];
  isDeleted: boolean;

  constructor(name: string) {
    this.name = name;
    this.workoutId = 0;
    this.days = [];
  }
}
