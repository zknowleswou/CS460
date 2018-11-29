import {Set} from './Set';

export class SetRecord {
    setRecordId: number;
    workoutSessionId: number;
    name: string;
    setId: number;
    exerciseId: number;
    order: number;
    goalRepititions: number;
    completedRepititions: number;
    goalWeight: number;
    completedWeight: number;
    skipped: boolean;

    constructor(set: Set, workoutSessionId: number){
        this.name = set.name;
        this.setId = set.setId;
        this.exerciseId = set.exerciseId
        this.order = set.order;
        this.goalRepititions = set.repititions;
        this.goalWeight = set.weight;
        this.completedRepititions = set.repititions;
        this.completedWeight = set.weight
        this.workoutSessionId = workoutSessionId;
      }
}