import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Utente } from '../../models/utente/utente';
import { UtenteService } from '../../services/utente/utente.service';

@Component({
  selector: 'app-utente-lista',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './utente-lista.component.html',
  styleUrl: './utente-lista.component.css'
})
export class UtenteListaComponent {

  elencoutenti: Utente[] = [];
  successo: boolean = false;

  constructor(private service: UtenteService) {

  }

  ngOnInit() {
    this.stampaTabella();
  }

  stampaTabella() {
    this.elencoutenti = this.service.ListaUtenti();
  }

  elimina(varCodice?: string) {
    if (varCodice && varCodice.trim() !== "") {
      if (this.service.EliminaUtente(varCodice)) {
        this.stampaTabella();

        this.successo = true;

        setTimeout(() => {
          this.successo = false;
        }, 2000);
      }
    }
  }
}