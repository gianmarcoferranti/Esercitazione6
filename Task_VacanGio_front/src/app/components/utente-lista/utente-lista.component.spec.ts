import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UtenteListaComponent } from './utente-lista.component';

describe('UtenteListaComponent', () => {
  let component: UtenteListaComponent;
  let fixture: ComponentFixture<UtenteListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UtenteListaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UtenteListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
