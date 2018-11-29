import { DesignWorkoutModule } from './design-workout.module';

describe('DesignWorkoutModule', () => {
  let designWorkoutModule: DesignWorkoutModule;

  beforeEach(() => {
    designWorkoutModule = new DesignWorkoutModule();
  });

  it('should create an instance', () => {
    expect(designWorkoutModule).toBeTruthy();
  });
});
