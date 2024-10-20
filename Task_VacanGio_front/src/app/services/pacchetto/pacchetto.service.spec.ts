import { TestBed } from '@angular/core/testing';

import { PacchettoService } from './pacchetto.service';

describe('PacchettoService', () => {
  let service: PacchettoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PacchettoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
