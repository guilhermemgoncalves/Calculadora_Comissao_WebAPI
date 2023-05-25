namespace Calculadora_Comissao_WebAPI.Models
{
    public class Comissao
    {
        public int Vendedor { get; set; }
        public int Mes { get; set; }
        public string Valor { get; set; } = null!;
    }
}