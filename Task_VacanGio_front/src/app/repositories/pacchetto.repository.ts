import { Injectable } from "@angular/core";
import { Pacchetto } from "../models/pacchetto/pacchetto";

@Injectable({
    providedIn: 'root'
})
export class PacchettoRepository {

    private elenco: Pacchetto[] =  [];

    constructor() {

    }

    Create(p: Pacchetto): boolean{
        this.elenco.push(p);
        localStorage.setItem("pacchetto", JSON.stringify(this.elenco))
        
        return true;
    }

    GetAll(): Pacchetto[] {

        let endpoint = "http://localhost:5172/api/pacchetti";
    
        // $.ajax({
        //     url: endpoint,
        //     type: "GET",
        //     success: function(risultato){
        //         console.log(risultato)
        //     },
        //     error: function(errore){
        //         console.log(errore)
        //     }
        // })

        fetch(endpoint)
            .then(risultatoResponse => risultatoResponse.json())
            .then(corpo => {
                corpo.forEach((element: Pacchetto)=> {
                    this.elenco.push(element);
                    console.log(element);

                });
            })
            .catch(errore => {
                console.log(errore)
            });
            return this.elenco;
    }

    GetAllByDesCode(pacc: string): Pacchetto[] {

        let endpoint = "http://localhost:5172/api/pacchetti/{{ pacc }}";
    
        // $.ajax({
        //     url: endpoint,
        //     type: "GET",
        //     success: function(risultato){
        //         console.log(risultato)
        //     },
        //     error: function(errore){
        //         console.log(errore)
        //     }
        // })

        fetch(endpoint)
            .then(risultatoResponse => risultatoResponse.json())
            .then(corpo => {
                corpo.forEach((element: Pacchetto)=> {
                    this.elenco.push(element);
                    console.log(element);

                });
            })
            .catch(errore => {
                console.log(errore)
            });
            return this.elenco;
    }

    /**
     * Funzione per l'eliminazine dal local storage di un elemento
     * @param varCod codice univoco dell'elemento sotto forma di UUID
     * @returns risultato booleano dell'eliminazione: true | false
     */
    Delete(varCod: string): boolean{
        let risultato: boolean = true;

        for(let [idx, item] of this.elenco.entries()){
            if(item.cod === varCod){
                this.elenco.splice(idx, 1);
                risultato = true;
                localStorage.setItem("negozio", JSON.stringify(this.elenco))
            }
        }

        return risultato;
    }

    GetById(varCod: string): Pacchetto | null{
        let risultato: Pacchetto | null = null;

        for(let [idx, item] of this.elenco.entries()){
            if(item.cod === varCod){
                risultato = item;
            }
        }

        return risultato;
    }

    Update(objProd: Pacchetto): boolean{
        let risultato: boolean = false;

        for(let i=0;i<this.elenco.length; i++){
            if(this.elenco[i].cod === objProd.cod){
                this.elenco[i].nom = objProd.nom;
    
            }
        }

        localStorage.setItem("pacchetto", JSON.stringify(this.elenco));
        risultato = true;

        return risultato;
    }
}