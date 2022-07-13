using AWS.PUC.Modelos;
using AWS.PUC.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AWS.PUC.API.Controllers
{
    public class TransferenciasController : Controller
    {
        public readonly ITransferenciaServico _transferenciaServico;

        public TransferenciasController(ITransferenciaServico transferenciaServico)
        {
            _transferenciaServico = transferenciaServico;
        }
        [HttpGet]
        [Route("v1/transferencias")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _transferenciaServico.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("v1/transferencias/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _transferenciaServico.Obter(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/transferencias")]
        public async Task<IActionResult> Post([FromBody] Transferencia transferencia)
        {
            try
            {
                await _transferenciaServico.Cadastrar(transferencia);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1/transferencias")]
        public async Task<IActionResult> Put([FromBody] Transferencia transferencia)
        {
            try
            {
                await _transferenciaServico.Editar(transferencia);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
