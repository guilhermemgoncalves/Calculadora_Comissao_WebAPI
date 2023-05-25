using Calculadora_Comissao_WebAPI.Models;
using Calculadora_Comissao_WebAPI.ModelViews;
using Calculadora_Comissao_WebAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora_Comissao_WebAPI.Controllers
{
    [Route("api/calcula-comissao")]
    [ApiController]
    public class ComissaoController : ControllerBase
    {
        private readonly ICalculaComissaoService calculaComissaoService;
      

        public ComissaoController(ICalculaComissaoService calculaComissaoService)
        {
            this.calculaComissaoService = calculaComissaoService;            
        }

      
        /// <summary>
        /// Ação que calcula comissão por mes 
        /// </summary>
        /// <param name="pedidoModelView"></param>
        /// <returns></returns>
        [HttpPost]
        public ComissoesModelView CalculaComissao(PedidoModelView pedidoModelView)
        {
            
            var comissao = calculaComissaoService.CalculaComissao(pedidoModelView);
            return comissao;

        }
    }
}
