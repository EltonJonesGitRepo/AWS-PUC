using AWS.PUC.Modelos;
using AWS.PUC.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS.PUC.API.Controllers
{
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly IPartidaServico _partidaServico;

        public PartidasController(IPartidaServico partidaServico)
        {
            _partidaServico = partidaServico;
        }

        [HttpGet]
        [Route("v1/partidas")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _partidaServico.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("v1/partidas/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _partidaServico.Obter(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/partidas")]
        public async Task<IActionResult> Post([FromBody] Partida time)
        {
            try
            {
                await _partidaServico.Cadastrar(time);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1/partidas")]
        public async Task<IActionResult> Put([FromBody] Partida time)
        {
            try
            {
                await _partidaServico.Editar(time);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("v1/partidas/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _partidaServico.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
