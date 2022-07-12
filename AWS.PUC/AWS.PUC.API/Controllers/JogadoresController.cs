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
    public class JogadoresController : ControllerBase
    {
        public readonly IJogadorServico _jogadorServico;

        public JogadoresController(IJogadorServico jogadorServico)
        {
            _jogadorServico = jogadorServico;
        }

        [HttpGet]
        [Route("v1/jogadores")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _jogadorServico.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/jogadores")]
        public async Task<IActionResult> Post([FromBody] Jogador jogador)
        {
            try
            {
                await _jogadorServico.Cadastrar(jogador);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1/jogadores")]
        public async Task<IActionResult> Put([FromBody] Jogador jogador)
        {
            try
            {
                await _jogadorServico.Editar(jogador);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("v1/jogadores/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _jogadorServico.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
