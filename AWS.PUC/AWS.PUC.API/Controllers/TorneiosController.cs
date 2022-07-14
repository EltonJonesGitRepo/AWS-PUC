using AWS.PUC.COMUM.Enumeradores;
using AWS.PUC.DTO;
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

        [HttpPost]
        [Route("v1/torneios")]
        public async Task<IActionResult> Post([FromBody] Torneio time)
        {
            try
            {
                await _torneioServico.Cadastrar(time);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1/torneios")]
        public async Task<IActionResult> Put([FromBody] Torneio time)
        {
            try
            {
                await _torneioServico.Editar(time);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPost]
        [Route("v1/torneios-partidas")]
        public async Task<IActionResult> AssiciarTorneioPartida([FromBody] TorneioPartidaInputDTO torneioPartidaInputDTO)
        {
            try
            {
                await _torneioServico.AssociarTorneioPartida(torneioPartidaInputDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1/torneios-partidas")]
        public async Task<IActionResult> EditarAssiciacaoTorneioPartida([FromBody] TorneioPartidaInputDTO torneioPartidaInputDTO)
        {
            try
            {
                await _torneioServico.EditarAssociacaoTorneioPartida(torneioPartidaInputDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

 
        [HttpDelete]
        [Route("v1/torneios/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _torneioServico.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        #region Eventos
        

        [HttpPost]
        [Route("v1/torneios/partidas/{idPartida}/eventos/inicio")]
        public async Task<IActionResult> IniciarPartida(Guid idPartida)
        {
            try
            {
                await _torneioServico.InicarPartida(idPartida);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("v1/torneios/partidas/{idPartida}/eventos/gol/{tipoGol}")]
        public async Task<IActionResult> CadastrarGol(Guid idPartida, TipoGolEnum tipoGol)
        {
            try
            {
                await _torneioServico.CadastrarGol(idPartida, tipoGol);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("v1/torneios/partidas/{idPartida}/eventos/intervalo")]
        public async Task<IActionResult> Intervalo(Guid idPartida)
        {
            try
            {
                await _torneioServico.CadastrarIntervalo(idPartida);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/torneios/partidas/{idPartida}/eventos/acrescimo/{acrescimoEmMinutos}")]
        public async Task<IActionResult> Acrescimo(Guid idPartida, int acrescimoEmMinutos)
        {
            try
            {
                await _torneioServico.CadastrarAcrescimo(idPartida, acrescimoEmMinutos);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/torneios/partidas/{idPartida}/eventos/substituicao")]
        public async Task<IActionResult> Substituicao(Guid idPartida)
        {
            try
            {
                await _torneioServico.CadastrarSubstituicao(idPartida);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/torneios/partidas/{idPartida}/eventos/advertencia")]
        public async Task<IActionResult> Advertencia(Guid idPartida)
        {
            try
            {
                await _torneioServico.CadastrarAdvertencia(idPartida);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/torneios/partidas/{idPartida}/eventos/fim")]
        public async Task<IActionResult> Fim(Guid idPartida)
        {
            try
            {
                await _torneioServico.EncerrarPartida(idPartida);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        #endregion Eventos
    }
}
