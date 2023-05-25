
using Calculadora_Comissao_WebAPI.ModelViews;
using FluentValidation;

namespace Calculadora_Comissao_WebAPI.Validators
{
    public class PedidoModelViewValidator : AbstractValidator<PedidoModelView>
    {
        public PedidoModelViewValidator()
        {
            RuleFor(x =>x.Pedidos).NotNull().NotEmpty();   
            RuleForEach(x => x.Pedidos).ChildRules(pedido =>
            {
                pedido.RuleFor(x => x.Valor).NotEmpty().NotNull().GreaterThan(0);
                pedido.RuleFor(x => x.Data).NotEmpty().NotNull();
                pedido.RuleFor(x => x.Vendedor).NotEmpty().NotNull();
            });                
        }
    }
}
