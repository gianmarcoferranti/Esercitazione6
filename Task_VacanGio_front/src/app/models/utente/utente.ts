export class Utente {
    cod: string | undefined;
    nom: string | undefined;
    cog: string | undefined;
    tel: number | undefined;
    ema: string | undefined;

    StampaDettaglio() : void{
        console.log(this.cod, this.nom, this.cog, this.tel, this.ema);
    }
}