using AWS.PUC.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS.PUC.API.Controllers
{
    [ApiController]
    public class TorneiosController : ControllerBase
    {
        private readonly ITorneioServico _torneioServico;

        public TorneiosController(ITorneioServico torneioServico)
        {
            _torneioServico = torneioServico;
        }

        [HttpGet]
        [Route("v1/torneios")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _torneioServico.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("v1/torneios/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _torneioServico.Obter(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
