using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace EventPlus.WebAPI.Controllers;

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
            if (loginDTO == null)
                return BadRequest("Dados do login não informados");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuario usuario = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

            if (usuario == null)
                return Unauthorized("Usuário não encontrado");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email ?? string.Empty),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("EventPlus-chave-autenticacao-webapi-dev"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "EventPlus.WebAPI",
                audience: "EventPlus.WebAPI",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);

        }
    }
}