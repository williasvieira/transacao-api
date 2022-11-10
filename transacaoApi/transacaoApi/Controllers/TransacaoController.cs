using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using transacaoApi.Interfaces;
using transacaoApi.Models.Dtos;

namespace transacaoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoService TransacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            TransacaoService = transacaoService;
        }

        [HttpPost("Transacao")]
        public IActionResult Transacao([FromBody] TransacaoDto transacao)
        {
            var retorno= TransacaoService.EfetuarTransacao(transacao).Result;
            return StatusCode(retorno);
            
        }
    }
}
