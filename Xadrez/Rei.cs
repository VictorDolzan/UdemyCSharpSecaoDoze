using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;

namespace CSharpSecapDoze.Xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro RTab, Cor RCor) : base(RTab, RCor)
        {            
        }

        public override string ToString()
        {
            return "R";
        }
    }
}