using System;

namespace Calculadora_Comissao_WebAPI.Helpers
{
    public static class TaxasComissaoHelper
    {
        static readonly Dictionary<int, int> metaPorMes =  new()
        {
            {1,5},
            {2,3}, 
            {3,2},
            {4,2},
            {5,5},
            {6,60},
            {8,2},
            {9,4},
            {10,4},
            {11,7},
            {12,2},
        };
      

        public static double ObterComissaoMetasMes(int mes, int quantidade, double totalVenda)
        {
            //validação mês 7, não consta meta
            if (mes == 7)
            {
                return 0;
            }

            if (metaPorMes[mes] > quantidade)
            {
                return 0;
            }

            return 0.03* totalVenda;
        }

        public static double ObterComissaoPorVenda(double valorVenda)
        {
            if (valorVenda < 300)
            {
                Console.WriteLine("Percentual de comissão:" +0.01);
                return valorVenda*0.01;
            }

            if  (valorVenda <1000)
            {
                Console.WriteLine("Percentual de comissão:" + 0.03);
                return valorVenda * 0.03;
            }

            Console.WriteLine("Percentual de comissão:" + 0.05);
            return valorVenda * 0.05;

        }


    }
}
