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

        //Endpoint Cadastrar
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Tarefa tarefa)
        {
            try
            {

                //Pega o valor do usuario que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                    c => c.Type == JwtRegisteredClaimNames.Jti);

                //Atribui o usuário a tarefa
                tarefa.UsuarioId = new System.Guid(usuarioid.Value);

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
        [HttpPut("{id}")]
        public IActionResult Editar(Guid id,Tarefa tarefa)
        {
            try
            {

                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                    c => c.Type == JwtRegisteredClaimNames.Jti);

                var tarefaexiste = _tarefaRepositorio.BuscarPorId(id);
                
                if (tarefa == null)
                    return NotFound();

                if (tarefaexiste.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário sem permissão");

                tarefa.Id = id;
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

                var tarefa = _tarefaRepositorio.BuscarPorId(IdTarefa);
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                    c => c.Type == JwtRegisteredClaimNames.Jti);

                if (tarefa == null)
                    return NotFound();

                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário sem permissão");

                _tarefaRepositorio.Remover(IdTarefa);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Endpoint ListarTodos
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                //Pega o valor do usuario que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                    c => c.Type == JwtRegisteredClaimNames.Jti);

                //Atribui o usuário a tarefa
                var tarefas = _tarefaRepositorio.Listar(
                                        new System.Guid(usuarioid.Value));

                return Ok(new { data = tarefas });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Authorize]
        /*api/tarefa/id*/
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                var tarefa = _tarefaRepositorio.BuscarPorId(id);
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                    c => c.Type == JwtRegisteredClaimNames.Jti);

                if (tarefa == null)
                    return NotFound();

                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário sem permissão");

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        //api/tarefa/status/idTarefa
        [HttpPut("status/{IdTarefa}")]
        public IActionResult AlterarStatus(Guid IdTarefa)
        {
            try
            {
                var tarefa = _tarefaRepositorio.BuscarPorId(IdTarefa);
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                    c => c.Type == JwtRegisteredClaimNames.Jti);

                if (tarefa == null)
                    return NotFound();

                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário sem permissão");

                _tarefaRepositorio.AlterarStatus(IdTarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
