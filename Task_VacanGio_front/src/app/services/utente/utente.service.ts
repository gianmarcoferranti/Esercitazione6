import { Injectable } from '@angular/core';

import { v4 as uuidv4 } from 'uuid';
import { Utente } from '../../models/utente/utente';
import { UtenteRepository } from '../../repositories/utente.repository';

@Injectable({
  providedIn: 'root'
})
export class UtenteService {

  constructor(private repo: UtenteRepository) { }

  InserisciUtente(prod: Utente): boolean{
    prod.cod = uuidv4();

    return this.repo.Create(prod);
  }

  ListaUtenti(): Utente[]{
    return this.repo.GetAll();
  }

  EliminaUtente(varCodice: string){
    return this.repo.Delete(varCodice);
  }

  DettaglioUtente(varCodice: string): Utente | null{
    return this.repo.GetById(varCodice);
  }

  ModificaUtente(objUtente: Utente): boolean{
    return this.repo.Update(objUtente);
  }
}
