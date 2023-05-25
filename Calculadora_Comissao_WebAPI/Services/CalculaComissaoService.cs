using Calculadora_Comissao_WebAPI.Helpers;
using Calculadora_Comissao_WebAPI.Models;
using Calculadora_Comissao_WebAPI.ModelViews;

namespace Calculadora_Comissao_WebAPI.Services
{
    public class CalculaComissaoService : ICalculaComissaoService
    {

        public ComissoesModelView CalculaComissao(PedidoModelView pedidosModelView)
        {

            var groupbyVendedor = pedidosModelView.Pedidos.GroupBy(p => p.Vendedor);
            ComissoesModelView comissoesModelView = new();

            foreach (var vendasPorVendedor in groupbyVendedor)
            {
                var vendasPorMesVendedor = vendasPorVendedor.GroupBy(x => x.Data.Month);

                foreach (var vendaMes in vendasPorMesVendedor)
                {
                   var comissaoVenda = CalculaComissaoPorMesVendedor(vendaMes);
                    comissoesModelView.Comissoes.Add(comissaoVenda);
                }               
            }

            return comissoesModelView;
        }

        private static Comissao CalculaComissaoPorMesVendedor(IGrouping<int, Pedido> vendaMes)
        {
            Comissao comissaoVenda = new();

            double comissaoPorVendas = 0;
            double totalVendasMes = 0;

            vendaMes.ToList().ForEach(venda =>
            {
                totalVendasMes += venda.Valor;
                comissaoVenda.Vendedor = venda.Vendedor;
                comissaoVenda.Mes = venda.Data.Month;
                comissaoPorVendas += TaxasComissaoHelper.ObterComissaoPorVenda(venda.Valor);
            });

            double comissaoPorMetasMes = TaxasComissaoHelper.ObterComissaoMetasMes(vendaMes.Count(), comissaoVenda.Mes, totalVendasMes);
            
            comissaoVenda.Valor = (comissaoPorMetasMes + comissaoPorVendas).ToString("F2");

            return comissaoVenda;
        }

    }
}
