using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayBasketController : Controller
    {
        [HttpPost]
        public ActionResult<string> AdicionarProduto([FromBody] Produto produto)
        {
            /*Implementar FromBody*/
            var requisicaoWeb = WebRequest.CreateHttp("https://localhost:44318/api/basket");
            requisicaoWeb.Method = "POST";
            requisicaoWeb.UserAgent = "APIGatewayIdentityBasket";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                return objResponse.ToString();
            }

        }

        [HttpPut("{id}")]
        public ActionResult<string> RemoverProdutoPorId(int id)
        {
            var requisicaoWeb = WebRequest.CreateHttp(string.Format("https://localhost:44318/api/basket/{0}", id));
            requisicaoWeb.Method = "PUT";
            requisicaoWeb.UserAgent = "APIGatewayIdentityBasket";

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