using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.Tabuleiro;

namespace CSharpSecapDoze
{
    class Program
    {
        public static void Main(string[] args)
        {
            Posicao P;

            P = new Posicao(3 ,4);

            Console.WriteLine("Posição: " + P);
        }
    }
}