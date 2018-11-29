import { TrackWorkoutModule } from './track-workout.module';

describe('TrackWorkoutModule', () => {
  let trackWorkoutModule: TrackWorkoutModule;

  beforeEach(() => {
    trackWorkoutModule = new TrackWorkoutModule();
  });

  it('should create an instance', () => {
    expect(trackWorkoutModule).toBeTruthy();
  });
});
