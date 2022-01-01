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
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro externalTab)
        {
            for (int contL = 0; contL < externalTab.TabLinhas; contL++)
            {
                Console.Write(8 - contL + " ");
                for (int contC = 0; contC < externalTab.TabColunas; contC++)
                {
                    if (externalTab.RetornarPecaT(contL, contC) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(externalTab.RetornarPecaT(contL, contC));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca externalPeca)
        {
            if(externalPeca.cor == Cor.Branca)
            {
                Console.Write(externalPeca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(externalPeca);
                Console.ForegroundColor = aux;
            }
        }
    }
}