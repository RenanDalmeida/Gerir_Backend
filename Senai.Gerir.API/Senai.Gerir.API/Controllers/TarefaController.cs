using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Gerir.API.Dominios;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Senai.Gerir.API.Interfaces;
using Senai.Gerir.API.Repositorios;
using Microsoft.AspNetCore.Authorization;

namespace Senai.Gerir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        //Criando um objeto _tarefaRepositorio
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController()
        {
            //Instanciando objeto
            _tarefaRepositorio = new TarefaRepositorio();
        }


        [HttpPost]

        public IActionResult Cadastrar(Tarefa tarefa)
        {
            try
            {
                _tarefaRepositorio.Cadastrar(tarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Endpoint Editar
        [Authorize]
        [HttpPut]
        public IActionResult Editar(Tarefa tarefa)
        {
            try
            { 
                _tarefaRepositorio.Editar(tarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        //Endpoint Remover
        [Authorize]
        [HttpDelete("{IdTarefa}")]

        public IActionResult Remover(Guid IdTarefa)
        {
            try
            {
                _tarefaRepositorio.Remover(IdTarefa);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
    }
}
