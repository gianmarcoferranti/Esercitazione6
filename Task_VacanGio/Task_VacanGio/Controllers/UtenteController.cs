using Microsoft.AspNetCore.Mvc;
using Task_VacanGio.Models;
using Task_VacanGio.Services;

namespace Task_VacanGio.Controllers
{
    [ApiController]
    [Route("api/utenti")]
    public class UtenteController : Controller
    {
        private readonly UtenteService _service;

        public UtenteController(UtenteService service)
        {
            _service = service;
        }

        [HttpGet("{varCodice}")]
        public ActionResult<UtenteDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            UtenteDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<UtenteDTO>> StampaUtenti()
        {

            List<UtenteDTO> risultato = _service.Lista();

            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaUtente(string varCodice)
        {
            if (varCodice.Trim() is not null)
            {
                UtenteDTO risultato;
                risultato = new UtenteDTO()
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
        public ActionResult<UtenteDTO?> InserisciUtente(string varNom, string varCog, int? varTel, string varEma)
        {
            if (varNom.Trim() is not null && varCog.Trim() is not null && varTel != null && varEma.Trim() is not null)
            {
                UtenteDTO risultato;
                risultato = new UtenteDTO()
                {
                    Cod = null,
                    Nom = varNom,
                    Cog = varCog,
                    Tel = varTel,
                    Ema = varEma
                };
                if (_service.InserisciUtente(risultato))
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
        public ActionResult<UtenteDTO?> UpdateVideoteca(string varCod, string? varNom,string? varCog, int? varTel, string? varEma)
        {

            if (varCod.Trim() is null || (varNom is null && varCog is null && varTel is null && varEma is null ))
            {
                return BadRequest();
            }
            else
            {
                UtenteDTO risultato = new UtenteDTO()
                {
                    Cod = varCod,
                    Nom = varNom,
                    Cog = varCog,
                    Tel = varTel,
                    Ema = varEma
                };
                if (_service.UpdateUtente(risultato))
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }

        }


    }
}
