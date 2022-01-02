using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;

namespace CSharpSecapDoze.Xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro externalTab, Cor externalCor) : base(externalTab, externalCor)
        {
        }
        public override string ToString()
        {
            return "D";
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornarPecaT(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.TabLinhas, tab.TabColunas];

            Posicao pos = new Posicao(0, 0);

            //Esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha, pos.coluna - 1);
            }
            //Direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha, pos.coluna + 1);
            }
            //Acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna);
            }
            //Abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna);
            }
            //Diagonal Superior Esquerda
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna - 1);
            }
            //Diagonal Superior Direita
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna + 1);
            }
            //Diagonal Inferior Direita
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna + 1);
            }
            //Diagonal Inferior Esquerda
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna - 1);
            }
            return mat;
        }
    }
}
