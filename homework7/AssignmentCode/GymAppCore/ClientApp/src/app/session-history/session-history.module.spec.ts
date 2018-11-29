import { SessionHistoryModule } from './session-history.module';

describe('SessionHistoryModule', () => {
  let sessionHistoryModule: SessionHistoryModule;

  beforeEach(() => {
    sessionHistoryModule = new SessionHistoryModule();
  });

  it('should create an instance', () => {
    expect(sessionHistoryModule).toBeTruthy();
  });
});
