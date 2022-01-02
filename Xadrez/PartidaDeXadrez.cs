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
        public Tabuleiro PDXTab { get; private set; }
        public int PDXTurno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> HSpecas;
        private HashSet<Peca> HSCapturadas;

        public PartidaDeXadrez()
        {
            PDXTab = new Tabuleiro(8, 8);
            PDXTurno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            HSpecas = new HashSet<Peca>();
            HSCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = PDXTab.RetirarPeca(origem);
            p.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = PDXTab.RetirarPeca(destino);
            PDXTab.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                HSCapturadas.Add(pecaCapturada);
            }


        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            PDXTurno++;
            MudaJogador();
        }
        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if (PDXTab.RetornarPecaT(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");

            }
            if (JogadorAtual != PDXTab.RetornarPecaT(origem).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!PDXTab.RetornarPecaT(origem).ExistemMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!PDXTab.RetornarPecaT(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in HSCapturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in HSpecas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            PDXTab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            HSpecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(PDXTab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(PDXTab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(PDXTab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(PDXTab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(PDXTab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(PDXTab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(PDXTab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(PDXTab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(PDXTab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(PDXTab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(PDXTab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(PDXTab, Cor.Preta));

        }
    }
}