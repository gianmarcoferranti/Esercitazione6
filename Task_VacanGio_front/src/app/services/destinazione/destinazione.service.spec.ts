import { TestBed } from '@angular/core/testing';

import { DestinazioneService } from './destinazione.service';

describe('DestinazioneService', () => {
  let service: DestinazioneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DestinazioneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
