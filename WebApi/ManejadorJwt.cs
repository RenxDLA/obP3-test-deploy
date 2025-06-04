using DTOs;
using LogicaAplicacion.InterfacesCU.IFuncionario;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

namespace WebApi
{
    public class ManejadorJwt
    {
        private static IObtenerFuncionarioCU _obtenerFuncionario { get; set; }
        public ManejadorJwt(IObtenerFuncionarioCU obtenerFuncionario)
        {
            _obtenerFuncionario = obtenerFuncionario;
        }
        public static FuncionarioDto ObtenerFuncionario(FuncionarioDto fun)
        {
            FuncionarioDto ret = _obtenerFuncionario.ObtenerFuncionario(fun);

            return ret;
        }

        public static string GenerarToken(FuncionarioDto funcionario, IConfiguration configuracion)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, funcionario.Email)
            };

            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuracion.GetSection("AppSettings:SecretTokenKey").Value));

            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}    
        
