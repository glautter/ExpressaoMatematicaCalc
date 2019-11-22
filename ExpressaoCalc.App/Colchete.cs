using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Colchete : Sinal
    {
        public override string SinalAberto { get => "["; }
        public override string SinalFechado { get => "]"; }
    }
}
