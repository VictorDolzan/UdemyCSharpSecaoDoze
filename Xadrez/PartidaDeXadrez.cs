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
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            PDXTab = new Tabuleiro(8, 8);
            PDXTurno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            xeque = false;
            HSpecas = new HashSet<Peca>();
            HSCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = PDXTab.RetirarPeca(origem);
            p.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = PDXTab.RetirarPeca(destino);
            PDXTab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                HSCapturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = PDXTab.RetirarPeca(destino);
            p.DecrementarQuantidadeMovimentos();
            if (pecaCapturada != null)
            {
                PDXTab.ColocarPeca(pecaCapturada, destino);
                HSCapturadas.Remove(pecaCapturada);
            }
            PDXTab.ColocarPeca(p, origem);
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCpturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCpturada);
                throw new TabuleiroException("Você não pode ser colocar em Xeque!");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (TesteXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {

                PDXTurno++;
                MudaJogador();
            }
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
            if (!PDXTab.RetornarPecaT(origem).MovimentoPossivel(destino))
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
            foreach (Peca x in HSCapturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in HSpecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        public bool EstaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não existe rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int contL = 0; contL < PDXTab.TabLinhas; contL++)
                {
                    for (int contC = 0; contC < PDXTab.TabColunas; contC++)
                    {
                        if (mat[contL, contC])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(contL, contC);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            PDXTab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            HSpecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(PDXTab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(PDXTab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(PDXTab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(PDXTab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(PDXTab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(PDXTab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(PDXTab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(PDXTab, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(PDXTab, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(PDXTab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(PDXTab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(PDXTab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(PDXTab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(PDXTab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(PDXTab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(PDXTab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(PDXTab, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(PDXTab, Cor.Preta, this));
        }
    }
}