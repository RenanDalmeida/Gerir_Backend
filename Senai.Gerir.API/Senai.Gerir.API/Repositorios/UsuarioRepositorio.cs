using Senai.Gerir.API.Contextos;
using Senai.Gerir.API.Dominios;
using Senai.Gerir.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Senai.Gerir.API.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        /* Declarando um objeto do tipo GerirContext que será a representação
        do banco de dados*/
        private readonly GerirContext _context;

        public UsuarioRepositorio()
        {
            //Cria uma instância de GerirContext
            _context = new GerirContext();
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Usuario Cadastrar(Usuario usuario)
        {
            try
            {
                //Adiciona um usuário ao DbSet Usuarios do contexto
                _context.Usuarios.Add(usuario);
                //Salva as alterações do contexto
                _context.SaveChanges();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario Editar(Usuario usuario)
        {
            try
            {
                //Busca o usuário no banco
                var usuarioexiste = BuscarPorId(usuario.Id);
                //Verifica se existe
                if (usuarioexiste == null)
                        throw new Exception("Usuário não encontrado");
                //Altera os valores do usuário
                usuarioexiste.Nome = usuario.Nome;
                usuarioexiste.Email = usuario.Email;

                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuarioexiste.Senha = usuario.Senha;

                //Altera e salva o banco
                _context.Usuarios.Update(usuarioexiste);
                _context.SaveChanges();

                return usuarioexiste;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Usuario Logar(string email, string senha)
        {
            try
            {
                var usuario = _context.Usuarios
                              .FirstOrDefault(c => c.Email == email && c.Senha == senha);

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                var usuario = BuscarPorId(id);

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
