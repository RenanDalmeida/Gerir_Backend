using Senai.Gerir.API.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.API.Interfaces
{
    interface IUsuarioRepositorio
    {
        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario">Contém os dados do usuário</param>
        /// <returns></returns>
        Usuario Cadastrar(Usuario usuario);

        /// <summary>
        /// Logar na conta
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Retorna usuário</returns>
        Usuario Logar(string email, string senha);

        /// <summary>
        /// Editar um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Id do Usuário</returns>
        Usuario Editar(Usuario usuario);

        /// <summary>
        /// Remover um usuário
        /// </summary>
        /// <param name="id"></param>
        void Remover(Guid id);

        /// <summary>
        /// Buscar usuário pelo ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna as informações do usuário</returns>
        Usuario BuscarPorId(Guid id);


    }
}
