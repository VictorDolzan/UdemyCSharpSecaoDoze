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
        private int PDXTurno;
        private Cor JogadorAtual;
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