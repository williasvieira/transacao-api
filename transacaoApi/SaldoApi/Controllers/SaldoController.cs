using Domain.Models;
using Domain.Models.Dtos;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SaldoApi.Interfaces;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SaldoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoController : Controller
    {
        
        private readonly ISaldoService SaldoService;
        private readonly ISaldoCacheService SaldoCacheService;
        public SaldoController(ISaldoService saldoService, ISaldoCacheService saldoCacheService)
        {
            SaldoService = saldoService;
           
            SaldoCacheService = saldoCacheService;
        }

        [HttpGet("{id}")]
        public IActionResult Saldo(string idUsuario)
        {
            var saldo = SaldoService.EfetuarSaldo(idUsuario).Result;
            return Ok(saldo);

        }
       
    }
}
