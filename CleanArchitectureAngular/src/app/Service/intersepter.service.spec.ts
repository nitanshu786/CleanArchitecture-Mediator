import { TestBed } from '@angular/core/testing';

import { IntersepterService } from './intersepter.service';

describe('IntersepterService', () => {
  let service: IntersepterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IntersepterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
