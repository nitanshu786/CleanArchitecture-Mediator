import { TestBed } from '@angular/core/testing';

import { TimingIntercepterService } from './timing-intercepter.service';

describe('TimingIntercepterService', () => {
  let service: TimingIntercepterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TimingIntercepterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
