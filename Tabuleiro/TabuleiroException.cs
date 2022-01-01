using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSharpSecapDoze.Xadrez;

namespace CSharpSecapDoze.TabuleiroX
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg)
        : base(msg)
        {            
        }
    }
}