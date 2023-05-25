using Calculadora_Comissao_WebAPI.ModelViews;

namespace Calculadora_Comissao_WebAPI.Services
{
    public interface ICalculaComissaoService
    {
        ComissoesModelView CalculaComissao(PedidoModelView pedidosModelView);
        
    }
}