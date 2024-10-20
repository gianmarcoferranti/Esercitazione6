export class Destinazione {
    cod: string | undefined;
    nom: string | undefined;
    des: string | undefined;
    pae: string | undefined;
    imm: string | undefined;

    StampaDettaglio() : void{
        console.log(this.cod, this.nom, this.des, this.pae, this.imm);
    }
}

