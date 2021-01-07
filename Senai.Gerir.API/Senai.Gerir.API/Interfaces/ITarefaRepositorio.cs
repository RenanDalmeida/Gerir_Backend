using Senai.Gerir.API.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.API.Interfaces
{
    interface ITarefaRepositorio
    {
        /// <summary>
        /// Cadastrar uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns>Retorna uma tarefa</returns>
        Tarefa Cadastrar(Tarefa tarefa);

        /// <summary>
        /// Listar todas as tarefas
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns>Retorna todas as tarefas</returns>
        List<Tarefa> Listar(Guid IdUsuario);

        /// <summary>
        /// Altera o status da tarefa
        /// </summary>
        /// <param name="IdTarefa"></param>
        /// <returns>Retorna uma tarefa</returns>
        Tarefa AlterarStatus(Guid IdTarefa);

        /// <summary>
        /// Editar uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns>O Id da tarefa</returns>
        Tarefa Editar(Tarefa tarefa);


        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="IdTarefa"></param>
        void Remover(Guid IdTarefa);

        /// <summary>
        /// Buscar uma tarefa por Id
        /// </summary>
        /// <param name="IdTarefa"></param>
        /// <returns>Retorna as informações da tarefa</returns>
        Tarefa BuscarPorId(Guid IdTarefa);

    }

}
