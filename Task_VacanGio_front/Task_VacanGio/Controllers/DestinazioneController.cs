using Microsoft.AspNetCore.Mvc;
using Task_VacanGio.Models;
using Task_VacanGio.Services;

namespace Task_VacanGio.Controllers
{
    [ApiController]
    [Route("api/destinazioni")]

    public class DestinazioneController : Controller
    {
        private readonly DestinazioneService _service;

        public DestinazioneController(DestinazioneService service)
        {
            _service = service;
        }

        [HttpGet("{varCodice}")]
        public ActionResult<DestinazioneDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            DestinazioneDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<DestinazioneDTO>> StampaDestinazioni()
        {

            List<DestinazioneDTO> risultato = _service.Lista();

            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaDestinazione(string varCodice)
        {
            if (varCodice.Trim() is not null)
            {
                DestinazioneDTO risultato;
                risultato = new DestinazioneDTO()
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
        public ActionResult<DestinazioneDTO?> InserisciDestinazione(string varNom, string varDes, string varPae, string varImm)
        {
            if (varNom.Trim() is not null && varDes.Trim() is not null && varPae.Trim() is not null && varImm.Trim() is not null)
            {
                DestinazioneDTO risultato;
                risultato = new DestinazioneDTO()
                {
                    Cod = null,
                    Nom = varNom,
                    Des = varDes,
                    Pae = varPae,
                    Imm = varImm
                };
                if (_service.InserisciDestinazione(risultato))
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
        public ActionResult<DestinazioneDTO?> UpdateDestinazione(string varCod, string? varNom, string? varDes, string? varPae, string? varImm)
        {

            if (varCod.Trim() is null || (varNom is null && varDes is null && varPae is null && varImm is null))
            {
                return BadRequest();
            }
            else
            {
                DestinazioneDTO risultato = new DestinazioneDTO()
                {
                    Cod = varCod,
                    Nom = varNom,
                    Des = varDes,
                    Pae = varPae,
                    Imm = varImm
                };
                if (_service.UpdateDestinazione(risultato))
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }

        }


    }
}

