import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Pacchetto } from '../../models/pacchetto/pacchetto';
import { PacchettoService } from '../../services/pacchetto/pacchetto.service';

@Component({
  selector: 'app-pacchetto-lista',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './pacchetto-lista.component.html',
  styleUrl: './pacchetto-lista.component.css'
})
export class PacchettoListaComponent {

  elencopacchetti: Pacchetto[] = [];
  successo: boolean = false;

  constructor(private service: PacchettoService) {

  }

  ngOnInit() {
    this.stampaTabella();
  }

  stampaTabella() {
    this.elencopacchetti = this.service.ListaPacchetti();
  }

  elimina(varCodice?: string) {
    if (varCodice && varCodice.trim() !== "") {
      if (this.service.EliminaPacchetto(varCodice)) {
        this.stampaTabella();

        this.successo = true;

        setTimeout(() => {
          this.successo = false;
        }, 2000);
      }
    }
  }
}
