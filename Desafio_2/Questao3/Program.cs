using System;
using System.Collections.Generic;
using static System.Console;
using static System.Int32;
using System.Linq;

namespace Questao3
{
    class Program
    {
        static void Main(string[] args)
        {
            AnaliseAcoes();
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) {}
            
        }

        static void AnaliseAcoes()
        {
            var ListaAcoes = new List<int>();
            int diaCompra = 0;
            int diaVenda = 0;
            int ValorCompra = 0;
            int ValorVenda = 0;

            Console.Write("Digite a quantidade de dias: ");
            var dias = int.Parse(ReadLine());

            Console.Write("Digite os valores das ações: ");
            for (int i = 0; i < dias; i++)
            {
                ListaAcoes.Add(int.Parse(ReadLine()));
            }

            for (int i = ListaAcoes.Count-1; i > 0; i--)
            {
                if (ListaAcoes[i] > ValorVenda )
                {
                    diaVenda = i + 1;
                    ValorVenda = ListaAcoes[i];
                }
            }

            for (int i = diaVenda-2; i >= 0; i--)
            {
                if (ListaAcoes[i] < ValorVenda && ListaAcoes[i] < ValorCompra || (ValorCompra == 0) )
                {
                    diaCompra = i + 1;
                    ValorCompra = ListaAcoes[i];
                }
            }

            var valorFinal = ValorVenda - ValorCompra;

            if (valorFinal > 0)
                Console.Write($"Comprou no dia {diaCompra} por {ValorCompra} e vendeu no dia {diaVenda} por {ValorVenda}, lucro foi de {valorFinal} \n");
            else
                Console.Write($"Nenhuma transação deve ser feita.\n");
        }
        
    }
}
