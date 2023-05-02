using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiCriminalistica.Components;
using WebApiCriminalistica.Data;
using WebApiCriminalistica.Models;
using WebApiCriminalistica.Models.component;

namespace WebApiCriminalistica.services
{
    public class usuarioApiService: IUsuarioApi
    {
        private readonly IConfiguration configuration;

        private readonly WebApiCriminalisticaContext _context;

        public usuarioApiService(IConfiguration configuration)
        {

            this.configuration = configuration;
        }

        public usuarioApiService(WebApiCriminalisticaContext context)
        {
            _context = context;
        }
        public usuarioApi Auteticacion(authApi authApi) { 
        
            usuarioApi respuesta = new usuarioApi();

            using (var DBcontext = _context) {

                try
                {
                    var obj = DBcontext.UsuarioCriminalistica
                        .AsNoTracking()
                        .SingleOrDefault(r => r.usuarioRepo == authApi.usuarioRepo);

                    if (obj != null)
                    {
                        respuesta.idUsuarioToken = obj.userCreaRepo;
                        respuesta.token = GenerarTokenJWT(authApi);
                    }
                    else 
                    {
                        throw new Exception("Usuario desconocido");
                    }
                }
                catch (Exception ex) { 
                
                }

                return respuesta;
            }
        }

        private string GenerarTokenJWT(authApi usuarioInfo)
        {
            // Cabecera
            var _symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecretaJWT"]));

            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var _Header = new JwtHeader(_signingCredentials);
            // Claims
            var _Claims = new[] {
                 new Claim(JwtRegisteredClaim.usuarioRepo, usuarioInfo.usuarioRepo),
            };

            //Payload
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddHours(24));

            //Token
            var _Token = new JwtSecurityToken(_Header, _Payload);
            string token = new JwtSecurityTokenHandler().WriteToken(_Token);

            return token;
        }

    }
}
