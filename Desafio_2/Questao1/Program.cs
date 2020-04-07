using System;
using System.Collections.Generic;
using static System.Console;
using static System.Int32;

namespace Questao1
{
    class Program
    {
        static void Main(string[] args)
        {
            Indices();
        }

        static void Indices()
        {
            int[] Dados = new int[]{2, 7, 11, 15,6,3};

            Write("Valor Alvo: ");
            var valor = Parse(ReadLine());

            for (int i = 0; i < Dados.Length; i++)
            {
                for (int j = 0; j < Dados.Length; j++)
                {
                  if (Dados[j] + Dados[i] == valor && j < i)
                  {        
                       Write($"[{j},{i}] ={valor} \n");
                  }
                }
            }
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) {}
        }
    }
}

