using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.TabuleiroX;
using CSharpSecapDoze.Xadrez;

namespace CSharpSecapDoze
{
    class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                Tabuleiro tab = new(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(3, 5));

                Tela.ImprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}