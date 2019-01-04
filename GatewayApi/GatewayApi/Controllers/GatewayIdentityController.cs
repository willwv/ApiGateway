using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdentityApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayIdentityController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> ValidarUsuario(string usuario, [FromBody] string senha)
        {
            /*Implementar FromBody*/
            var requisicaoWeb = WebRequest.CreateHttp(string.Format("https://localhost:44341/api/identity/{0}",usuario));
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "APIGatewayIdentity";


            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                return objResponse.ToString();
            }
        }

        [HttpPut("{usuario}")]
        public ActionResult<string> AlterarSenha(int usuario, [FromBody] Senhas senhas)
        {
            /*Implementar FromBody*/
            var requisicaoWeb = WebRequest.CreateHttp(string.Format("https://localhost:44341/api/identity/{0}", usuario));
            requisicaoWeb.Method = "PUT";
            requisicaoWeb.UserAgent = "APIGatewayIdentity";


            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();                
                return objResponse.ToString();
            }
        }
    }
}
