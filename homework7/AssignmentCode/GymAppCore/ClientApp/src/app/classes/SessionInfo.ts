
export class SessionInfo {
    exerciseIndex: number;
    setIndex: number;
    workoutSessionId: number;

    constructor(exerciseIndex: number, setIndex: number, workoutSessionId: number) {
        this.exerciseIndex = exerciseIndex;
        this.setIndex = setIndex;
        this.workoutSessionId = workoutSessionId;
    }
}
