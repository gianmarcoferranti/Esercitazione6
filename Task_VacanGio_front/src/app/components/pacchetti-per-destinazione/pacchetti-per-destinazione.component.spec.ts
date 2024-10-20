import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacchettiPerDestinazioneComponent } from './pacchetti-per-destinazione.component';

describe('PacchettiPerDestinazioneComponent', () => {
  let component: PacchettiPerDestinazioneComponent;
  let fixture: ComponentFixture<PacchettiPerDestinazioneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PacchettiPerDestinazioneComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PacchettiPerDestinazioneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
