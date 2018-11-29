import { SessionHistoryRoutingModule } from './session-history-routing.module';

describe('SessionHistoryRoutingModule', () => {
  let sessionHistoryRoutingModule: SessionHistoryRoutingModule;

  beforeEach(() => {
    sessionHistoryRoutingModule = new SessionHistoryRoutingModule();
  });

  it('should create an instance', () => {
    expect(sessionHistoryRoutingModule).toBeTruthy();
  });
});
