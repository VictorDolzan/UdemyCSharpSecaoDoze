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
                for (int contC = 0; contC < externalTab.TabColunas; contC++)
                {
                    if (externalTab.RetornarPecaT(contL, contC) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(externalTab.RetornarPecaT(contL, contC) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}