using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;

namespace CSharpSecapDoze.Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro ToTab, Cor ToCor) : base(ToTab, ToCor)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}