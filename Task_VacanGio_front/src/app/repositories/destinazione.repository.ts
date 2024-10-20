import { Injectable } from "@angular/core";
import { Destinazione } from "../models/destinazione/destinazione";

@Injectable({
    providedIn: 'root'
})
export class DestinazioneRepository {

    private elenco: Destinazione[] =  [];

    constructor() {

    }

    Create(p: Destinazione): boolean{
        this.elenco.push(p);
        localStorage.setItem("destinazione", JSON.stringify(this.elenco))
        
        return true;
    }

    GetAll(): Destinazione[] {

        let endpoint = "http://localhost:5172/api/destinazioni";
    
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
                corpo.forEach((element: Destinazione)=> {
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
                localStorage.setItem("destinazione", JSON.stringify(this.elenco))
            }
        }

        return risultato;
    }

    GetById(varCod: string): Destinazione | null{
        let risultato: Destinazione | null = null;

        for(let [idx, item] of this.elenco.entries()){
            if(item.cod === varCod){
                risultato = item;
            }
        }

        return risultato;
    }

    Update(objProd: Destinazione): boolean{
        let risultato: boolean = false;

        for(let i=0;i<this.elenco.length; i++){
            if(this.elenco[i].cod === objProd.cod){
                this.elenco[i].nom = objProd.nom;
          
            }
        }

        localStorage.setItem("destinazione", JSON.stringify(this.elenco));
        risultato = true;

        return risultato;
    }
}