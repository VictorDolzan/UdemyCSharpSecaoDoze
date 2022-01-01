using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CSharpSecapDoze.TabuleiroX
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Posicao(int externalLinha, int externalColuna)
        {
            linha = externalLinha;
            coluna = externalColuna;
        }
        public void DefinirValores(int externalLinha, int externalColuna)
        {
            linha = externalLinha;
            coluna = externalColuna;
        }

        public override string ToString()
        {
            return linha
            + ", "
            + coluna;
        }
    }
}
