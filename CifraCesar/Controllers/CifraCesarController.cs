using CifraCesar.Facades;
using Microsoft.AspNetCore.Mvc;

namespace CifraCesar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CifraCesarController : ControllerBase
    {
        private CifraCesarFacade _facade = new CifraCesarFacade();

        [HttpPost("codificar")]
        public IActionResult Codificar([FromBody] string word)
        {
            try
            {
                return Ok(_facade.Codificar(word.ToLower()));
            }
            catch
            {
                return BadRequest("Insira apenas letras sem acento, espaços, pontos e vírgulas");
            }
        }

        [HttpPost("decodificar")]
        public IActionResult Decodificar([FromBody] string word)
        {
            try
            {
                return Ok(_facade.Decodificar(word.ToLower()));
            }
            catch
            {
                return BadRequest("Insira apenas letras sem acento, espaços, pontos e vírgulas");
            }
        }
    }
}