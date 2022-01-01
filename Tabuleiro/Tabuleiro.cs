using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.Xadrez;

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

        public Peca RetornarPecaT(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return RetornarPecaT(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if(ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= TabLinhas || pos.coluna < 0 || pos.coluna >= TabColunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if(!PosicaoValida(pos))
            {
                throw new TabuleiroException(" Posição inválida!");
            }
        }
    }
}