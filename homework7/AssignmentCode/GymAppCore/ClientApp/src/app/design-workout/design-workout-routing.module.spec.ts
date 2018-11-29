import { DesignWorkoutRoutingModule } from './design-workout-routing.module';

describe('DesignWorkoutRoutingModule', () => {
  let designWorkoutRoutingModule: DesignWorkoutRoutingModule;

  beforeEach(() => {
    designWorkoutRoutingModule = new DesignWorkoutRoutingModule();
  });

  it('should create an instance', () => {
    expect(designWorkoutRoutingModule).toBeTruthy();
  });
});
