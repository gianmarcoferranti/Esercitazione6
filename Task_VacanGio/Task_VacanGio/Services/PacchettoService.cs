using Task_VacanGio.Models;
using Task_VacanGio.Repos;

namespace Task_VacanGio.Services
{
    public class PacchettoService
    {
        private readonly PacchettoRepo _repository;
        private readonly DestinazioneRepo _destinazioneRepository;
        private readonly TrattaRepo _trattaRepo;

        public PacchettoService(PacchettoRepo repository, DestinazioneRepo destinazioneRepository, TrattaRepo trattaRepo)
        {
            _repository = repository;
            _destinazioneRepository = destinazioneRepository;
            _trattaRepo = trattaRepo;
        }

        public PacchettoDTO? Cerca(string varCod)
        {
            PacchettoDTO? risultato = null;

            Pacchetto? pacchetto = _repository.GetByCodice(varCod);
            if (pacchetto is not null)
            {
                risultato = new PacchettoDTO()
                {
                    Cod = pacchetto.Codice,
                    Nom = pacchetto.Nome,
                    Pre = pacchetto.Prezzo,
                    Dur = pacchetto.Durata,
                    Din = pacchetto.DataInizio,
                    Dfi = pacchetto.DataFine
                };

            }

            return risultato;
        }

        // prende tutti i pacchetti per la destinazione data
        public List<PacchettoDTO> CercaPerCodiceDestinazione(string varCod)
        {
            //cerco l'id della destinazione dal codice
            Destinazione? des = new Destinazione();
            des = _destinazioneRepository.GetByCodice(varCod);
            List<PacchettoDTO> risultato = new List<PacchettoDTO>();
            if (des is not null)
            {
                // chiamo direttamente la repo di tratta
                IEnumerable<Pacchetto> elenco = _trattaRepo.GetByCodiceDestination(des.DestinazioneID);
                foreach (var pacchetto in elenco)
                    if (pacchetto is not null)
                    {
                        PacchettoDTO risultatoTemp;
                        risultatoTemp = new PacchettoDTO()
                        {
                            Cod = pacchetto.Codice,
                            Nom = pacchetto.Nome,
                            Pre = pacchetto.Prezzo,
                            Dur = pacchetto.Durata,
                            Din = pacchetto.DataInizio,
                            Dfi = pacchetto.DataFine
                        };
                        risultato.Add(risultatoTemp);
                    }
            }
            return risultato;
        }

        public PacchettoDTO? CercaPerID(int varCod)
        {
            PacchettoDTO? risultato = null;

            Pacchetto? pacchetto = _repository.Get(varCod);
            if (pacchetto is not null)
            {
                risultato = new PacchettoDTO()
                {
                    Cod = pacchetto.Codice,
                    Nom = pacchetto.Nome,
                    Pre = pacchetto.Prezzo,
                    Dur = pacchetto.Durata,
                    Din = pacchetto.DataInizio,
                    Dfi = pacchetto.DataFine
                };

            }

            return risultato;
        }

        public int? CercaPacchettoIDPerCodice(string varCod)
        {
            int? risultato = null;


            Pacchetto? pacchetto = _repository.GetByCodice(varCod);
            if (pacchetto is not null)
            {
                risultato = pacchetto.PacchettoID;

            }



            return risultato;
        }



        public List<PacchettoDTO> Lista()
        {
            List<PacchettoDTO> risultato = new List<PacchettoDTO>();

            IEnumerable<Pacchetto> elenco = _repository.GetAll();
            foreach (var pacchetto in elenco)
                if (pacchetto is not null)
                {
                    PacchettoDTO risultatoTemp;
                    risultatoTemp = new PacchettoDTO()
                    {
                        Cod = pacchetto.Codice,
                        Nom = pacchetto.Nome,
                        Pre = pacchetto.Prezzo,
                        Dur = pacchetto.Durata,
                        Din = pacchetto.DataInizio,
                        Dfi = pacchetto.DataFine
                    };
                    risultato.Add(risultatoTemp);
                }

            return risultato;
        }

        public bool Elimina(PacchettoDTO pacchettoDTO)
        {
            bool risultato = false;
            if (pacchettoDTO is not null && pacchettoDTO.Cod is not null)
            {
                Pacchetto? pacchetto = null;
                pacchetto = new Pacchetto()
                {
                    Codice = pacchettoDTO.Cod
                };
                if (_repository.Elimina(pacchetto))
                {
                    risultato = true;
                }
            }
            return risultato;
        }

        public bool InserisciPacchetto(PacchettoDTO pacchettoDTO)
        {
            bool risultato = false;
            if (pacchettoDTO is not null && pacchettoDTO.Nom is not null && pacchettoDTO.Pre is not null && pacchettoDTO.Dur is not null
                && pacchettoDTO.Din != default && pacchettoDTO.Dfi != default)
            {
                pacchettoDTO.Cod = Guid.NewGuid().ToString().ToUpper();
                Pacchetto? pacchetto = null;
                pacchetto = new Pacchetto()
                {
                    Codice = pacchettoDTO.Cod,
                    Nome = pacchettoDTO.Nom,
                    Prezzo = pacchettoDTO.Pre,
                    Durata = pacchettoDTO.Dur,
                    DataInizio = pacchettoDTO.Din,
                    DataFine = pacchettoDTO.Dfi
                };
                if (_repository.Create(pacchetto))
                {
                    risultato = true;
                }
            }
            return risultato;
        }

        public bool UpdatePacchetto(PacchettoDTO pacchettoDTO)
        {
            bool risultato = false;



            if (pacchettoDTO != null && !string.IsNullOrWhiteSpace(pacchettoDTO.Cod))
            {
                var pacchettoRitorno = _repository.GetByCodice(pacchettoDTO.Cod);
                if (pacchettoRitorno != null)
                {
                    if (!string.IsNullOrWhiteSpace(pacchettoDTO.Nom))
                    {
                        pacchettoRitorno.Nome = pacchettoDTO.Nom;
                    }

                    if (pacchettoDTO.Pre is not null)
                    {
                        pacchettoRitorno.Prezzo = pacchettoDTO.Pre;
                    }
                    if (pacchettoDTO.Dur is not null)
                    {
                        pacchettoRitorno.Durata = pacchettoDTO.Dur;
                    }
                    if (pacchettoDTO.Din is not null)
                    {
                        pacchettoRitorno.DataInizio = pacchettoDTO.Din;
                    }
                    if (pacchettoDTO.Dfi is not null)
                    {
                        pacchettoRitorno.DataFine = pacchettoDTO.Dfi;
                    }

                    if (_repository.Update(pacchettoRitorno))
                    {
                        risultato = true;
                    }
                }
            }

            return risultato;
        }

    }
}
