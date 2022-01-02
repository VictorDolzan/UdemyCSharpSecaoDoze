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

       private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornarPecaT(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.TabLinhas, tab.TabColunas];
            
            Posicao pos = new Posicao(0,0);

            //ACIMA
            pos.DefinirValores(posicao.linha -1, posicao.coluna);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                } 
                pos.linha = pos.linha - 1;
            }
            //Abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                } 
                pos.linha = pos.linha + 1;
            }
            //Direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                } 
                pos.coluna = pos.coluna + 1;
            }
            //Esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornarPecaT(pos) != null && tab.RetornarPecaT(pos).cor != cor)
                {
                    break;
                } 
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}