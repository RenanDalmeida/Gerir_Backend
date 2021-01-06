using Senai.Gerir.API.Contextos;
using Senai.Gerir.API.Dominios;
using Senai.Gerir.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.API.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {

        /* Declarando um objeto do tipo GerirContext que será a representação
        do banco de dados*/
        private readonly GerirContext _context;

        public TarefaRepositorio()
    {
            //Instanciando GerirContext
            _context = new GerirContext();
    }
        public Tarefa AlterarStatus(Guid IdTarefa)
        {
            throw new NotImplementedException();
        }

        public Tarefa BuscarPorId(Guid IdTarefa)
        {
            try
            {
                var tarefa = _context.Tarefas.Find(IdTarefa);

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa Cadastrar(Tarefa tarefa)
        {
            try
            {
                //Adiciona um usuário ao DbSet Usuarios do contexto
                _context.Tarefas.Add(tarefa);
                //Salva as alterações do contexto
                _context.SaveChanges();

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa Editar(Tarefa tarefa)
        {
            try
            {
                //Busca o usuário no banco
                var tarefaexiste = BuscarPorId(tarefa.Id);
                //Verifica se existe
                if (tarefaexiste == null)
                    throw new Exception("Usuário não encontrado");
                //Altera os valores do usuário
                tarefaexiste.Descricao = tarefa.Descricao;
                tarefaexiste.Categoria = tarefa.Categoria;
                                               
                //Altera e salva o banco
                _context.Tarefas.Update(tarefaexiste);
                _context.SaveChanges();

                return tarefaexiste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Tarefa> ListarTodos(Guid IdUsuario)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid IdTarefa)
        {
            try
            {
                var tarefa = BuscarPorId(IdTarefa);

                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
