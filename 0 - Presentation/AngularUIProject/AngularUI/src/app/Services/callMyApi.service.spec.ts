/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CallMyApiService } from './callMyApi.service';

describe('Service: CallMyApi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CallMyApiService]
    });
  });

  it('should ...', inject([CallMyApiService], (service: CallMyApiService) => {
    expect(service).toBeTruthy();
  }));
});
