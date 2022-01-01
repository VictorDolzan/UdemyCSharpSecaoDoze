using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;


namespace CSharpSecapDoze
{
    class Program
    {
        public static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.ImprimirTabuleiro(tab);            
        }
    }
}