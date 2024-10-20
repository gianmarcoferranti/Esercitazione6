import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinazioneListaComponent } from './destinazione-lista.component';

describe('DestinazioneListaComponent', () => {
  let component: DestinazioneListaComponent;
  let fixture: ComponentFixture<DestinazioneListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DestinazioneListaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DestinazioneListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
