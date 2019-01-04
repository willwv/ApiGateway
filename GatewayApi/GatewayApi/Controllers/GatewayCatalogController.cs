using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using BasketApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayCatalogController : Controller
    {
        [HttpGet]
        public ActionResult<string> ListarProdutos()
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://localhost:5001/api/catalog");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "APIGatewayIdentityCatalog";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                return objResponse.ToString();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> ProdutoPorId(int id)
        {
            var requisicaoWeb = WebRequest.CreateHttp(string.Format("http://localhost:1337/{0}", id));
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "APIGatewayIdentityCatalog";

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