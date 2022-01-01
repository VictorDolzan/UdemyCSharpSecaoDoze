using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CSharpSecapDoze.TabuleiroX
{
    class Peca 
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Posicao externalPosicao, Tabuleiro externalTab, Cor externalCor )
        {
            posicao = externalPosicao;
            tab = externalTab;
            cor = externalCor;
            qtMovimentos = 0;
        }
    }
}