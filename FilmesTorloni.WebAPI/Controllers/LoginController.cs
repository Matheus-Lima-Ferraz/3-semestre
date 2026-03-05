using FilmesTorloni.WebAPI.DTO;
using FilmesTorloni.WebAPI.Interfaces;
using FilmesTorloni.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FilmesTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public IActionResult Login(LoginDTO loginDTO)
    {
        try
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha inválidos!");
            }

            //Caso encotre o usuário, prosseguir para criação de token

            //1º - Definir as informações(claims) que serão fornecidas no token (Payload)

            var claims = new[]
            {
                //formato da claim          
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario),

                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),

                //existe a possibilidade de criar uma claim personalizada
                //new Claim("Claim Personalizad", "Valor da claim personalizada")
            };

            //2º- definir a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

            //3º - Definir as credenciais do token (HEADER)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //4º - Gerar token
            var token = new JwtSecurityToken
                (
                //emissor do token
                issuer: "api_filmes",

                //destinatário do token
                audience: "api_filmes",

                //dados definidos nas claims(informações)
                claims: claims,

                //tempo de expiração do token
                expires: DateTime.Now.AddMinutes(5),

                //credenciais do token
                signingCredentials: creds
                );

            //5º - Retorna o token criado
            return Ok(new
            {  
                 TokenContext = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}
