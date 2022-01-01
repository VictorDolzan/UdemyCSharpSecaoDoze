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

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornarPecaT(pos);
            return p == null || p.cor != this.cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.TabLinhas, tab.TabColunas];
            
            Posicao pos = new Posicao(0,0);

            //ACIMA

            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            
            //Diagonal Superior Direita(NE(Nordeste))

            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Direita

            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal Inferior Direita(SE(Sudeste))

            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Abaixo

            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal Inferior Direita(SO(Sudoeste))

            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Esquerda

            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal Superior Esquerda(NO(Noroeste))

            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }
    }
}