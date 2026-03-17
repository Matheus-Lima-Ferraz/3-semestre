using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Busca o usuário pelo e-mail e valida o hash da senha
    /// </summary>
    /// <param name="Email">Email do usuário a ser buscado</param>
    /// <param name="Senha">Senha para validar o usuário</param>
    /// <returns>Usuário buscado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Email == Email);

        if (usuarioBuscado != null)
        {
            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }

        }
        return null!;
    }
    /// <summary>
    /// Busca um usuario pelo id, incluindo os dados do seu tipo de usaurio
    /// </summary>
    /// <param name="id">id do usuario a ser buscado</param>
    /// <returns>usuário buscado e seu tipo de usuário </returns>
    public Usuario BuscarPorId(Guid id)
    {
        return _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.IdUsuario == id)!;
    }
    /// <summary>
    /// Cadastra um novo usuário, A senha é criptografia e o Id gerado pelo banco de dados. 
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Castar(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}
