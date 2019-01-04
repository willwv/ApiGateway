using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayMarketingController : Controller
    {        
        [HttpGet]
        public ActionResult<string> ObterPromocoes()
        {
            var requisicaoWeb = WebRequest.CreateHttp("http://localhost:1337/");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "APIGatewayIdentityMarketing";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                return objResponse.ToString();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<string> ObterPromocoesPorId(int id)
        {
            var requisicaoWeb = WebRequest.CreateHttp(string.Format("http://localhost:1337/{0}", id));
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "APIGatewayIdentityMarketing";

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