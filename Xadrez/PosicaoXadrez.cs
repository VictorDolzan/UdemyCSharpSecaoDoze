using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;

namespace CSharpSecapDoze.Xadrez
{
    class PosicaoXadrez
    {
        public char PXColuna { get; set; }
        public int PXLinha { get; set; }

        public PosicaoXadrez(char externalPXColuna, int externalPXLinha)
        {
            PXColuna = externalPXColuna;
            PXLinha = externalPXLinha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - PXLinha, PXColuna - 'a');
        }

        public override string ToString()
        {
            return "" 
            + PXColuna 
            + PXLinha;
        }
    }
}