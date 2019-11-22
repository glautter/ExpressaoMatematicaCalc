using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Chave : Sinal
    {
        public override string SinalAberto { get => "{"; }
        public override string SinalFechado { get => "}"; }
    }
}
