export class Set {
  name: string;
  setId: number;
  exerciseId: number;
  order: number;
  repititions: number;
  weight: number;
  isDeleted: boolean;

  constructor(setName: string, exerciseId: number) {
    this.name = setName;
    this.exerciseId = exerciseId;
  }
}
