using Microsoft.AspNetCore.Mvc;
using Task_VacanGio.Models;
using Task_VacanGio.Services;

namespace Task_VacanGio.Controllers
{
    [ApiController]
    [Route("api/recensioni")]
    public class RecensioneController : Controller
    {

        private readonly RecensioneService _service;

        public RecensioneController(RecensioneService service)
        {
            _service = service;
        }

        [HttpGet("{varCodice}")]
        public ActionResult<RecensioneDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            RecensioneDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<RecensioneDTO>> StampaRecensioni()
        {

            List<RecensioneDTO> risultato = _service.Lista();

            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaRecensione(string varCodice)
        {
            if (varCodice.Trim() is not null)
            {
                RecensioneDTO risultato;
                risultato = new RecensioneDTO()
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
        public ActionResult<RecensioneDTO?> InserisciRecensione(string varCodUte, string varCodPac, int? varVot, string varComm)
        {
            if (varCodUte.Trim() is not null && varCodPac is not null && varVot != null && varComm.Trim() is not null)
            {


                RecensioneDTO risultato;
                risultato = new RecensioneDTO()
                {
                    Cod = null,
                    Vot = varVot,
                    Comm = varComm,
                    Dtr = DateOnly.FromDateTime(DateTime.Now),
                    Ute = new UtenteDTO() { Cod = varCodUte },
                    Pac = new PacchettoDTO() { Cod = varCodPac }
                };
                if (_service.InserisciRecensione(risultato))
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
        public ActionResult<RecensioneDTO?> UpdateRecensione(string varCod, int? varVot, string varComm)
        {

            if (varCod.Trim() is null || (varVot is null && varComm is null ))
            {
                return BadRequest();
            }
            else
            {
                RecensioneDTO risultato = new RecensioneDTO()
                {
                    Cod = varCod,
                    Vot = varVot,
                    Comm = varComm,
                };
                if (_service.UpdateRecensione(risultato))
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }

        }

    }
}
