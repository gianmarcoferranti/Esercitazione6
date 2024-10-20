import { Routes } from '@angular/router';
import { UtenteListaComponent } from './components/utente-lista/utente-lista.component';
import { HomeComponent } from './components/home/home.component';
import { PacchettoListaComponent } from './components/pacchetto-lista/pacchetto-lista.component';
import { DestinazioneListaComponent } from './components/destinazione-lista/destinazione-lista.component';
import { PacchettiPerDestinazioneComponent } from './components/pacchetti-per-destinazione/pacchetti-per-destinazione.component';

export const routes: Routes = [
    {path: "", redirectTo: "home", pathMatch: "full"},
    {path: "utenti/lista", component: UtenteListaComponent},
    {path: "home", component:HomeComponent},
    {path: "pacchetti/lista", component: PacchettoListaComponent},
    {path: "destinazioni/lista", component: DestinazioneListaComponent},
    {path: "pacchettiperdestinazione/lista", component: PacchettiPerDestinazioneComponent}
 
];