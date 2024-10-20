import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Destinazione } from '../../models/destinazione/destinazione';
import { DestinazioneService } from '../../services/destinazione/destinazione.service';

@Component({
  selector: 'app-destinazione-lista',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './destinazione-lista.component.html',
  styleUrl: './destinazione-lista.component.css'
})
export class DestinazioneListaComponent {

  
  elencodestinazioni: Destinazione[] = [];
  successo: boolean = false;

  constructor(private service: DestinazioneService) {

  }

  ngOnInit() {
    this.stampaTabella();
  }

  stampaTabella() {
    this.elencodestinazioni = this.service.ListaDestinazioni();
  }

  elimina(varCodice?: string) {
    if (varCodice && varCodice.trim() !== "") {
      if (this.service.EliminaDestinazione(varCodice)) {
        this.stampaTabella();

        this.successo = true;

        setTimeout(() => {
          this.successo = false;
        }, 2000);
      }
    }
  }

}
