import { Set } from './Set';

export class Exercise {
  name: string;
  exerciseId: number;
  dayId: number;
  order: number;
  sets: Set[];
  isDeleted: boolean;

  constructor(name: string, dayId: number) {
    this.name = name;
    this.dayId = dayId;
    this.sets = [];
  }
}
