import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacchettoListaComponent } from './pacchetto-lista.component';

describe('PacchettoListaComponent', () => {
  let component: PacchettoListaComponent;
  let fixture: ComponentFixture<PacchettoListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PacchettoListaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PacchettoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
