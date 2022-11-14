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
        private readonly ITransacaoInfraService TransacaoInfraService;
        private readonly ISaldoService SaldoService;
        private readonly ISaldoCacheService SaldoCacheService;
        public SaldoController(ISaldoService saldoService, ITransacaoInfraService transacaoInfraService, ISaldoCacheService saldoCacheService)
        {
            SaldoService = saldoService;
            TransacaoInfraService = transacaoInfraService;
            SaldoCacheService = saldoCacheService;
        }

        [HttpPost("Saldo")]
        public IActionResult Saldo(string idUsuario)
        {
            var saldo = SaldoService.EfetuarSaldo(idUsuario).Result;
            return Ok(saldo);

        }
        [HttpPost("Create")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            SaldoCacheService.Add(usuario);
            return Created("", usuario);
        }
        //public IActionResult PostTransacao([FromBody] TransacaoDto transacaoDto)
        //{
        //    Transacao trasacao = new Transacao(transacaoDto.IdUsuario, transacaoDto.Valor);
        //     TransacaoInfraService.RegistarTransacao(trasacao);

        //    return Created("", trasacao);


        //}
    }
}
