using Task_VacanGio.Models;
using Task_VacanGio.Repos;

namespace Task_VacanGio.Services
{
    public class RecensioneService
    {
        private readonly RecensioneRepo _repository;
        private readonly UtenteService _cliService;
        private readonly PacchettoService _pacchettoService;

        public RecensioneService(RecensioneRepo repository, UtenteService cliService, PacchettoService pacService)
        {
            _repository = repository;
            _cliService = cliService;
            _pacchettoService = pacService;
        }

        public RecensioneDTO? Cerca(string varCod)
        {
            RecensioneDTO? risultato = null;

            Recensione? recensione = _repository.GetByCodice(varCod);
            if (recensione is not null)
            {
                risultato = new RecensioneDTO()
                {
                    Cod = recensione.Codice,
                    Vot = recensione.Voto,
                    Comm = recensione.Commento,
                    Dtr = recensione.DataRecensione
             
                };

            }

            return risultato;
        }



        public List<RecensioneDTO> Lista()
        {
            List<RecensioneDTO> risultato = new List<RecensioneDTO>();

            IEnumerable<Recensione> elenco = _repository.GetAll();
            foreach (var recensione in elenco)
                if (recensione is not null)
                {
                    RecensioneDTO risultatoTemp;
                    risultatoTemp = new RecensioneDTO()
                    {
                        Cod = recensione.Codice,
                        Vot = recensione.Voto,
                        Comm = recensione.Commento,
                        Dtr = recensione.DataRecensione,
                        Ute = _cliService.CercaPerID(recensione.UtenteRif),
                        Pac = _pacchettoService.CercaPerID(recensione.PacchettoRif)

                    };
                    risultato.Add(risultatoTemp);
                }

            return risultato;
        }

        public bool Elimina(RecensioneDTO recensioneDTO)
        {
            bool risultato = false;
            if (recensioneDTO is not null && recensioneDTO.Cod is not null)
            {
                Recensione? recensione = null;
                recensione = new Recensione()
                {
                    Codice = recensioneDTO.Cod
                };
                if (_repository.Elimina(recensione))
                {
                    risultato = true;
                }
            }
            return risultato;
        }

        public bool InserisciRecensione(RecensioneDTO recensioneDTO)
        {
            bool risultato = false;

            if (recensioneDTO != null && recensioneDTO.Ute is not null && recensioneDTO.Ute.Cod is not null && recensioneDTO.Pac is not null 
                 && recensioneDTO.Pac.Cod is not null)
            {
                int? riferimentoCli = _cliService.CercaUtenteIDPerCodice(recensioneDTO.Ute.Cod);
                int? riferimentoPac = _pacchettoService.CercaPacchettoIDPerCodice(recensioneDTO.Pac.Cod);
                if (riferimentoCli != null && riferimentoPac != null)
                {
                    if (recensioneDTO.Vot != null && recensioneDTO.Comm != null)
                    {
                        recensioneDTO.Cod = Guid.NewGuid().ToString().ToUpper();
                        Recensione recensione = new Recensione()
                        {
                            Codice = recensioneDTO.Cod,
                            Voto = recensioneDTO.Vot,
                            Commento = recensioneDTO.Comm,
                            DataRecensione = recensioneDTO.Dtr,
                            UtenteRif = (int)riferimentoCli, 
                            PacchettoRif = (int)riferimentoPac
                        };
                        if (_repository.Create(recensione))
                        {
                            risultato = true;
                        }
                    }
                }
            }

            return risultato;
        }


        public bool UpdateRecensione(RecensioneDTO recensioneDTO)
        {
            bool risultato = false;



            if (recensioneDTO != null && !string.IsNullOrWhiteSpace(recensioneDTO.Cod))
            {
                var recensioneRitorno = _repository.GetByCodice(recensioneDTO.Cod);
                if (recensioneRitorno != null)
                {
                    if (recensioneDTO.Vot is not null)
                    {
                        recensioneRitorno.Voto = recensioneDTO.Vot;
                    }

                    if (!string.IsNullOrWhiteSpace(recensioneDTO.Comm))
                    {
                        recensioneRitorno.Commento = recensioneDTO.Comm;
                    }
                    if (recensioneDTO.Dtr is not null)
                    {
                        recensioneRitorno.DataRecensione = recensioneDTO.Dtr;
                    }
                   

                    if (_repository.Update(recensioneRitorno))
                    {
                        risultato = true;
                    }
                }
            }

            return risultato;
        }
    }
}
