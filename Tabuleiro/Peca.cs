using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.Xadrez;

namespace CSharpSecapDoze.TabuleiroX
{
    abstract class Peca 
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro externalTab, Cor externalCor )
        {
            posicao = null;
            this.tab = externalTab;
            this.cor = externalCor;
            qtMovimentos = 0;
        }
        public void IncrementarQuantidadeMovimentos()
        {
            qtMovimentos++;
        }

        public abstract bool[,] MovimentosPossiveis();
        
    }
}