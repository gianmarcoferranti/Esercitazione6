using Microsoft.AspNetCore.Mvc;
using Task_VacanGio.Models;
using Task_VacanGio.Services;

namespace Task_VacanGio.Controllers
{
    [ApiController]
    [Route("api/pacchetti")]
    public class PacchettoController : Controller
    {
        private readonly PacchettoService _service;

        public PacchettoController(PacchettoService service)
        {
            _service = service;
        }

        [HttpGet("{varCodice}")]
        public ActionResult<PacchettoDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            PacchettoDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        
  


        //trova tutti i pacchetti per codice di destinazione
        [HttpGet("pacchetto/{varCodiceDestinazione}")]

        public ActionResult<List<PacchettoDTO>> CercaPerCodiceDestinazione(string varCodiceDestinazione)
        {
            if (string.IsNullOrWhiteSpace(varCodiceDestinazione))
                return BadRequest();

            List<PacchettoDTO> risultato = _service.CercaPerCodiceDestinazione(varCodiceDestinazione);

            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<PacchettoDTO>> StampaPacchetti()
        {

            List<PacchettoDTO> risultato = _service.Lista();

            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaPacchetto(string varCodice)
        {
            if (varCodice.Trim() is not null)
            {
                PacchettoDTO risultato;
                risultato = new PacchettoDTO()
                {
                    Cod = varCodice
                };
                if (_service.Elimina(risultato))
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<PacchettoDTO?> InserisciPacchetto(string varNom, decimal varPre, int? varDur, DateOnly varDin, DateOnly varDfi)
        {
            if (varNom.Trim() is not null && varNom.Trim() is not null && varPre >= 0 && varDin != default && varDfi != default)
            {
                PacchettoDTO risultato;
                risultato = new PacchettoDTO()
                {
                    Cod = null,
                    Nom = varNom,
                    Pre = varPre,
                    Dur = varDur,
                    Din = varDin,
                    Dfi =varDfi
                };
                if (_service.InserisciPacchetto(risultato))
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public ActionResult<PacchettoDTO?> UpdatePacchetto(string varCod, string? varNom, decimal? varPre, int? varDur, DateOnly? varDin, DateOnly? varDfi)
        {

            if ((string.IsNullOrWhiteSpace(varCod)) ||
        (string.IsNullOrWhiteSpace(varNom) && varPre >= 0 && varDur is not null
        && varDin != default && varDfi != default))
            {
                return BadRequest();
            }
            else
            {
                PacchettoDTO risultato = new PacchettoDTO()
                {
                    Cod = varCod,
                    Nom = varNom,
                    Pre = varPre,
                    Dur = varDur,
                    Din = varDin,
                    Dfi = varDfi
                };
                if (_service.UpdatePacchetto(risultato))
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }

        }


    }

}
