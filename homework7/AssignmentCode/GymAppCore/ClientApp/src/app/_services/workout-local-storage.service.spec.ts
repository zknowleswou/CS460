import { TestBed } from '@angular/core/testing';

import { WorkoutLocalStorageService } from './workout-local-storage.service';

describe('WorkoutLocalStorageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkoutLocalStorageService = TestBed.get(WorkoutLocalStorageService);
    expect(service).toBeTruthy();
  });
});
