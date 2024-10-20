import { Injectable } from '@angular/core';
import { PacchettoRepository } from '../../repositories/pacchetto.repository';
import { Pacchetto } from '../../models/pacchetto/pacchetto';
import { v4 as uuidv4 } from 'uuid';


@Injectable({
  providedIn: 'root'
})
export class PacchettoService {

  constructor(private repo: PacchettoRepository) { }

  
  InserisciPacchetto(prod: Pacchetto): boolean{
    prod.cod = uuidv4();

    return this.repo.Create(prod);
  }

  ListaPacchetti(): Pacchetto[]{
    return this.repo.GetAll();
  }
  ListaPacchettiPerDestinazione(pacc: string): Pacchetto[]{
    return this.repo.GetAllByDesCode(pacc);
  }

  EliminaPacchetto(varCodice: string){
    return this.repo.Delete(varCodice);
  }

  DettaglioPacchetto(varCodice: string): Pacchetto | null{
    return this.repo.GetById(varCodice);
  }

  ModificaPacchetto(objPacchetto: Pacchetto): boolean{
    return this.repo.Update(objPacchetto);
  }
}
