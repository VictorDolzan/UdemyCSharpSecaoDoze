using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CSharpSecapDoze.TabuleiroX
{
    class Tabuleiro
    {
        public int TabLinhas { get; set; }
        public int TabColunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int externalLinhas, int externalColunas)
        {
            TabLinhas = externalLinhas;
            TabColunas = externalColunas;
            pecas = new Peca[externalLinhas, externalColunas];
        }
        public Peca RetornarPecaT(int externalLinha, int externalColuna)
        {
            return pecas[externalLinha, externalColuna];
        }
    }
}