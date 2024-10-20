import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Pacchetto } from '../../models/pacchetto/pacchetto';
import { PacchettoService } from '../../services/pacchetto/pacchetto.service';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-pacchetti-per-destinazione',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './pacchetti-per-destinazione.component.html',
  styleUrl: './pacchetti-per-destinazione.component.css'
})
export class PacchettiPerDestinazioneComponent {

  codice: string | undefined;

  
  elencopacchettiperdest: Pacchetto[] = [];
  successo: boolean = false;

  constructor(
    private rottaAttiva: ActivatedRoute, 
    private service: PacchettoService,
    private router: Router) {

  }


  ngOnInit(){
    this.rottaAttiva.params.subscribe( (risultato) => {
      this.codice = risultato['codice'];
      if(this.codice && this.codice.trim() !== ""){
        
        let pac = this.service.ListaPacchettiPerDestinazione(this.codice);
        this.elencopacchettiperdest = pac;
      }
    })
  }


  // ngOnInit() {
  //   this.stampaTabella();
  // }

  // stampaTabella() {
  //   this.elencopacchettiperdest = this.service.ListaPacchettiPerDestinazione();
  // }

}
