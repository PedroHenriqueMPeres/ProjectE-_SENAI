using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EventPlus_.Domains.StringLenght;
using EventPlus_.DTO;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
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
                    return NotFound("Usuário não encontrado, email ou senha invalidos");
                }

                // caso o usuario seja encontrado, prossegue para a criacao do token

                // 1* passo - definir as claims() que serao fornecidos no token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.UsuarioID.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),

                    new Claim("Nome da Claim","Valor da Claim")
                };

                // 2* passo - definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Eventos-chave-autenticacao-webapi-dev"));

                // 3* passo - definir as credenciais do token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4* passo - gerar o token
                var token = new JwtSecurityToken
                    (
                        // emissor do token
                        issuer: "EventPlus",

                        // destinatário do token
                        audience: "EventPlus",

                        // dados definidos nas claims
                        claims: claims,

                        // tempo de expiração do token
                        expires: DateTime.Now.AddMinutes(5),

                        // credenciais do token
                        signingCredentials: creds

                    );

                // retorna o token
                return Ok
                    (
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                        }
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
