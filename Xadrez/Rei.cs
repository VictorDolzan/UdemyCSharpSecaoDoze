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
        private PartidaDeXadrez RPartidaDeXadrez;
        public Rei(Tabuleiro RTab, Cor RCor, PartidaDeXadrez partida) : base(RTab, RCor)
        {      
            RPartidaDeXadrez = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornarPecaT(pos);
            return p == null || p.cor != cor;
        }
        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = tab.RetornarPecaT(pos);
            return p != null && p is Torre && p.cor == cor && p.qtMovimentos == 0;
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

            //Jogada Especial Roque
            if(qtMovimentos == 0 && !RPartidaDeXadrez.xeque)
            {
                //Jogada especial Roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if(TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tab.RetornarPecaT(p1) == null && tab.RetornarPecaT(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                 //Jogada especial Roque Grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if(TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if(tab.RetornarPecaT(p1) == null && tab.RetornarPecaT(p2) == null && tab.RetornarPecaT(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }



            return mat;
        }
    }
}