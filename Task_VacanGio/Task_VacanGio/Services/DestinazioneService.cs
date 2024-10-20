using Task_VacanGio.Models;
using Task_VacanGio.Repos;

namespace Task_VacanGio.Services
{
    public class DestinazioneService
    {
        private readonly DestinazioneRepo _repository;

        public DestinazioneService(DestinazioneRepo repository)
        {
            _repository = repository;
        }

        public DestinazioneDTO? Cerca(string varCod)
        {
            DestinazioneDTO? risultato = null;

            Destinazione? destinazione = _repository.GetByCodice(varCod);
            if (destinazione is not null)
            {
                risultato = new DestinazioneDTO()
                {
                    Cod = destinazione.Codice,
                    Nom = destinazione.Nome,
                    Des = destinazione.Descrizione,
                    Pae = destinazione.Paese,
                    Imm = destinazione.Immagine
                };

            }

            return risultato;
        }
     


        public List<DestinazioneDTO> Lista()
        {
            List<DestinazioneDTO> risultato = new List<DestinazioneDTO>();

            IEnumerable<Destinazione> elenco = _repository.GetAll();
            foreach (var destinazione in elenco)
                if (destinazione is not null)
                {
                    DestinazioneDTO risultatoTemp;
                    risultatoTemp = new DestinazioneDTO()
                    {
                        Cod = destinazione.Codice,
                        Nom = destinazione.Nome,
                        Des = destinazione.Descrizione,
                        Pae = destinazione.Paese,
                        Imm = destinazione.Immagine
                    };
                    risultato.Add(risultatoTemp);
                }

            return risultato;
        }

        public bool Elimina(DestinazioneDTO destinazioneDTO)
        {
            bool risultato = false;
            if (destinazioneDTO is not null && destinazioneDTO.Cod is not null)
            {
                Destinazione? destinazione = null;
                destinazione = new Destinazione()
                {
                    Codice = destinazioneDTO.Cod
                };
                if (_repository.Elimina(destinazione))
                {
                    risultato = true;
                }
            }
            return risultato;
        }

        public bool InserisciDestinazione(DestinazioneDTO destinazioneDTO)
        {
            bool risultato = false;
            if (destinazioneDTO is not null && destinazioneDTO.Nom is not null && destinazioneDTO.Des is not null && destinazioneDTO.Pae is not null && destinazioneDTO.Imm is not null)
            {
                destinazioneDTO.Cod = Guid.NewGuid().ToString().ToUpper();
                Destinazione? destinazione = null;
                destinazione = new Destinazione()
                {
                    Codice = destinazioneDTO.Cod,
                    Nome = destinazioneDTO.Nom,
                    Descrizione = destinazioneDTO.Des,
                    Paese = destinazioneDTO.Pae,
                    Immagine = destinazioneDTO.Imm
                };
                if (_repository.Create(destinazione))
                {
                    risultato = true;
                }
            }
            return risultato;
        }

        public bool UpdateDestinazione(DestinazioneDTO destinazioneDTO)
        {
            bool risultato = false;



            if (destinazioneDTO != null && !string.IsNullOrWhiteSpace(destinazioneDTO.Cod))
            {
                var destinazioneRitorno = _repository.GetByCodice(destinazioneDTO.Cod);
                if (destinazioneRitorno != null)
                {
                    if (!string.IsNullOrWhiteSpace(destinazioneDTO.Nom))
                    {
                        destinazioneRitorno.Nome = destinazioneDTO.Nom;
                    }

                    if (!string.IsNullOrWhiteSpace(destinazioneDTO.Des))
                    {
                        destinazioneRitorno.Descrizione = destinazioneDTO.Des;
                    }
                    if (!string.IsNullOrWhiteSpace(destinazioneDTO.Pae))
                    {
                        destinazioneRitorno.Paese = destinazioneDTO.Pae;
                    }
                    if (!string.IsNullOrWhiteSpace(destinazioneDTO.Imm))
                    {
                        destinazioneRitorno.Immagine = destinazioneDTO.Imm;
                    }

                    if (_repository.Update(destinazioneRitorno))
                    {
                        risultato = true;
                    }
                }
            }

            return risultato;
        }

    }
}

