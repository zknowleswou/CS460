import { TrackWorkoutRoutingModule } from './track-workout-routing.module';

describe('TrackWorkoutRoutingModule', () => {
  let trackWorkoutRoutingModule: TrackWorkoutRoutingModule;

  beforeEach(() => {
    trackWorkoutRoutingModule = new TrackWorkoutRoutingModule();
  });

  it('should create an instance', () => {
    expect(trackWorkoutRoutingModule).toBeTruthy();
  });
});
