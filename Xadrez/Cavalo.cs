using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;

namespace CSharpSecapDoze.Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro externalTab, Cor externalCor) : base(externalTab, externalCor)
        {
        }
        public override string ToString()
        {
            return "C";
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornarPecaT(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.TabLinhas, tab.TabColunas];

            Posicao pos = new Posicao(0,0);

            
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 2);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            pos.DefinirValores(posicao.linha - 2, posicao.coluna - 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            pos.DefinirValores(posicao.linha - 2, posicao.coluna + 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 2);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 2);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            pos.DefinirValores(posicao.linha + 2, posicao.coluna + 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            pos.DefinirValores(posicao.linha + 2, posicao.coluna - 1);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 2);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;                
            }
            return mat;
        }
    }
}