using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;
using CSharpSecapDoze.Xadrez;

namespace CSharpSecapDoze
{
    class Program
    {
        public static void Main(string[] args)
        {
           PosicaoXadrez pos = new('c', 7);

           Console.WriteLine(pos);

           Console.WriteLine(pos.ToPosicao());
        }
    }
}