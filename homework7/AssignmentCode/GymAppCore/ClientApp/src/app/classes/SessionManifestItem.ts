export class SessionManifestItem {
    isComplete: boolean;
    workoutSessionId: number;
    dayId: number;
    sessionStart: Date;
    startDateString: string;

    constructor(workoutSessionId: number, dayId: number) {
        this.workoutSessionId = workoutSessionId;
        this.dayId = dayId;

        this.isComplete = false;
        this.sessionStart = new Date();
        this.startDateString = this.createSessionStartString(this.sessionStart);
    }

    private createSessionStartString(date: Date): string {
        var monthNames = [
            "Jan", "Feb", "Mar",
            "Apr", "May", "Jun", "Jul",
            "Aug", "Sep", "Oct",
            "Nov", "Dec"
        ];

        var day = date.getDate();
        var monthIndex = date.getMonth();
        var year = date.getFullYear();

        return day + ' ' + monthNames[monthIndex] + ' ' + year;
    }
}