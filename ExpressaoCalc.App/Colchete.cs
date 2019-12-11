using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Colchete : Agrupador
    {
        public override string AgrupadorAberto { get => "["; }
        public override string AgrupadorFechado { get => "]"; }
    }
}
