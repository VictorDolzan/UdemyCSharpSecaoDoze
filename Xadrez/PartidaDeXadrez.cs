using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;

namespace CSharpSecapDoze.Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro PDXTab{ get; private set; }
        public int PDXTurno{ get; private set; }
        public Cor JogadorAtual{ get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            PDXTab = new Tabuleiro(8, 8);
            PDXTurno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = PDXTab.RetirarPeca(origem);
            p.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = PDXTab.RetirarPeca(destino);
            PDXTab.ColocarPeca(p, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            PDXTurno++;
            MudaJogador();
        }
        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if(PDXTab.RetornarPecaT(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");

            }
            if(JogadorAtual != PDXTab.RetornarPecaT(origem).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if(!PDXTab.RetornarPecaT(origem).ExistemMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        private void MudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        private void ColocarPecas()
        {
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            PDXTab.ColocarPeca(new Rei(PDXTab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

             PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            PDXTab.ColocarPeca(new Torre(PDXTab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            PDXTab.ColocarPeca(new Rei(PDXTab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());


        }
    }
}