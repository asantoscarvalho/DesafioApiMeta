using System;
using System.Collections.Generic;
using static System.Console;
using static System.Int32;

namespace Questao2
{
    class Program
    {
        static void Main(string[] args)
        {
            Balanced();
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) {}
        }
        
        static void Balanced()
        {
            string[] fecha = new string[] {")","}","]"};

            string[] abre = new string[] {"(","{","["};

            var resultado = true;

            Write("Entre com os  caracteres: ");
            var bracketes = ReadLine();

            var tletra = bracketes.Length;

            if ((tletra%2 != 0))
            {
              Console.WriteLine("Não");
              return;
            }
             for (int i = 0; i < (tletra/2); i++)
             {
                var indexFecha = Array.FindIndex(abre, el => el == bracketes[i].ToString());
                var indiceBracket = (tletra-1) - i;
                
                if ((indexFecha < 0) || (bracketes[indiceBracket].ToString() != fecha[indexFecha]) )
                {
                    resultado = false;
                    break;
                }

             }

            var vSimNao = resultado ? "Sim" : "Não"; 
            Console.Write(vSimNao+"\n");
           
        }
    }
}
