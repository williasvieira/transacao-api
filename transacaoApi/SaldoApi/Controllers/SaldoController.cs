using Microsoft.AspNetCore.Mvc;
using SaldoApi.Interfaces;

namespace SaldoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoController : Controller
    {
        private readonly ISaldoService SaldoService;
        public SaldoController(ISaldoService saldoService)
        {
            SaldoService = saldoService;
        }

        [HttpPost("Saldo")]
        public IActionResult Saldo(int idUsuario)
        {
            var saldo = SaldoService.EfetuarSaldo(idUsuario).Result;
            return Ok(saldo);

        }
    }
}
