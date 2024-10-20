import { Injectable } from '@angular/core';
import { DestinazioneRepository } from '../../repositories/destinazione.repository';
import { Destinazione } from '../../models/destinazione/destinazione';
import { v4 as uuidv4 } from 'uuid';


@Injectable({
  providedIn: 'root'
})
export class DestinazioneService {

  constructor(private repo: DestinazioneRepository) { }

  InserisciDestinazione(prod: Destinazione): boolean{
    prod.cod = uuidv4();

    return this.repo.Create(prod);
  }

  ListaDestinazioni(): Destinazione[]{
    return this.repo.GetAll();
  }

  EliminaDestinazione(varCodice: string){
    return this.repo.Delete(varCodice);
  }

  DettaglioDestinazione(varCodice: string): Destinazione | null{
    return this.repo.GetById(varCodice);
  }

  ModificaDestinazione(objDestinazione: Destinazione): boolean{
    return this.repo.Update(objDestinazione);
  }
}
