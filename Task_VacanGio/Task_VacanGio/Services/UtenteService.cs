using Task_VacanGio.Models;
using Task_VacanGio.Repos;

namespace Task_VacanGio.Services
{
    public class UtenteService : IService<UtenteDTO>
    {
        private readonly UtenteRepo _repository;
        private readonly RecensioneRepo _recensioneRepository;

        public UtenteService(UtenteRepo repository, RecensioneRepo recensioneRepository)
        {
            _repository = repository;
            _recensioneRepository = recensioneRepository;
        }

        public UtenteDTO? Cerca(string varCod)
        {
            UtenteDTO? risultato = null;

            Utente? utente = _repository.GetByCodice(varCod);
            if (utente is not null)
            {
                risultato = new UtenteDTO()
                {
                    Cod = utente.Codice,
                    Nom = utente.Nome,
                    Cog = utente.Cognome,
                    Tel = utente.Telefono,
                    Ema = utente.Email
                };

            }

            return risultato;
        }

        public UtenteDTO? CercaPerID(int varID)
        {
            UtenteDTO? risultato = null;

            Utente? utente = _repository.Get(varID);
            if (utente is not null)
            {
                risultato = new UtenteDTO()
                {
                    Cod = utente.Codice,
                    Nom = utente.Nome,
                    Cog = utente.Cognome,
                    Tel = utente.Telefono,
                    Ema = utente.Email
                };

            }

            return risultato;
        }

        public int? CercaUtenteIDPerCodice(string varCod)
        {
            int? risultato = null;

            Utente? utente = _repository.GetByCodice(varCod);
            if (utente is not null)
            {
                risultato = utente.UtenteID;

            }

            return risultato;
        }



        public List<UtenteDTO> Lista()
        {
            List<UtenteDTO> risultato = new List<UtenteDTO>();

            IEnumerable<Utente> elenco = _repository.GetAll();
            foreach (var utente in elenco)
            {
                if (utente != null)
                {
                    List<Recensione> elencoRece = _recensioneRepository.GetByIdUtente(utente.UtenteID).ToList();
                    List<RecensioneDTO> elencoReceDTO = new List<RecensioneDTO>();

                    foreach (var rece in elencoRece)
                    {
                        if (rece != null)
                        {
                            RecensioneDTO receD = new RecensioneDTO()
                            {
                                Cod = rece.Codice,
                                Vot = rece.Voto,
                                Comm = rece.Commento,
                                Dtr = rece.DataRecensione
                            };
                            elencoReceDTO.Add(receD);
                        }
                    }

                    UtenteDTO risultatoTemp = new UtenteDTO()
                    {
                        Cod = utente.Codice,
                        Nom = utente.Nome,
                        Cog = utente.Cognome,
                        Tel = utente.Telefono,
                        Ema = utente.Email,
                        Ele = elencoReceDTO
                    };
                    risultato.Add(risultatoTemp);
                }
            }

            return risultato;
        }


        public bool Elimina(UtenteDTO userDTO)
        {
            bool risultato = false;
            if (userDTO is not null && userDTO.Cod is not null)
            {
                Utente? utente = null;
                utente = new Utente()
                {
                    Codice = userDTO.Cod
                };
                if (_repository.Elimina(utente))
                {
                    risultato = true;
                }
            }
            return risultato;
        }

        public bool InserisciUtente(UtenteDTO userDTO)
        {
            bool risultato = false;
            if (userDTO is not null && userDTO.Nom is not null && userDTO.Cog is not null && userDTO.Tel is not null && userDTO.Ema is not null)
            {
                userDTO.Cod = Guid.NewGuid().ToString().ToUpper();
                Utente? user = null;
                user = new Utente()
                {
                    Codice = userDTO.Cod,
                    Nome = userDTO.Nom,
                    Cognome = userDTO.Cog,
                    Telefono = userDTO.Tel,
                    Email = userDTO.Ema
                };
                if (_repository.Create(user))
                {
                    risultato = true;
                }
            }
            return risultato;
        }

        public bool UpdateUtente(UtenteDTO userDTO)
        {
            bool risultato = false;



            if (userDTO != null && !string.IsNullOrWhiteSpace(userDTO.Cod))
            {
                var utenteRitorno = _repository.GetByCodice(userDTO.Cod);
                if (utenteRitorno != null)
                {
                    if (!string.IsNullOrWhiteSpace(userDTO.Nom))
                    {
                        utenteRitorno.Nome = userDTO.Nom;
                    }

                    if (!string.IsNullOrWhiteSpace(userDTO.Cog))
                    {
                        utenteRitorno.Cognome = userDTO.Cog;
                    }
                    if (userDTO.Tel is not null)
                    {
                        utenteRitorno.Telefono = userDTO.Tel;
                    }
                    if (!string.IsNullOrWhiteSpace(userDTO.Ema))
                    {
                        utenteRitorno.Email = userDTO.Ema;
                    }

                    if (_repository.Update(utenteRitorno))
                    {
                        risultato = true;
                    }
                }
            }

            return risultato;
        }

    }
}
