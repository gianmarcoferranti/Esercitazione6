import { DecimalPipe } from "@angular/common";

export class Pacchetto {
    cod: string | undefined;
    nom: string | undefined;
    pre: DecimalPipe | undefined;
    dur: number | undefined;
    din: Date | undefined;
    dfi: Date | undefined;

    StampaDettaglio() : void{
        console.log(this.cod, this.nom, this.pre, this.dur, this.din, this.dfi);
    }
}
