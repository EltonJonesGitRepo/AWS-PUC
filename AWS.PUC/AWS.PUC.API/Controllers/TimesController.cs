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
    public class TimesController : ControllerBase
    {        
        private readonly ITimeServico _timeServico;
        
        public TimesController(ITimeServico timeServico)
        {            
            _timeServico = timeServico;
        }

        [HttpGet]
        [Route("v1/times")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _timeServico.Listar());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("v1/times/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _timeServico.Obter(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("v1/times")]
        public async Task<IActionResult> Post([FromBody] Time time)
        {
            try
            {
                await _timeServico.Cadastrar(time);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1/times")]
        public async Task<IActionResult> Put([FromBody] Time time)
        {
            try
            {
                await _timeServico.Editar(time);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("v1/times/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _timeServico.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
