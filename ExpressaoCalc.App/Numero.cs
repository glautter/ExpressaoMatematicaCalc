using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Numero
    {
        public int Valor { get; set; }
        private int Numero1 { get; set; }
        private int Numero2 { get; set; }

        public Numero() { }

        public Numero(int numero1, int numero2)
        {
            Numero1 = numero1;
            Numero2 = numero2;
        }

        public static Numero operator -(Numero c)
        {
            return new Numero { Valor = c.Numero1 -c.Numero2 };
        }
        public static Numero operator +(Numero c)
        {
            return new Numero { Valor = c.Numero1 +c.Numero2 };
        }
        public static Numero operator *(Numero c, Numero d)
        {
           return new Numero { Valor = c.Numero1 * d.Numero2 };
        }
        public static Numero operator /(Numero c, Numero b)
        {
            return new Numero { Valor = c.Numero1 / b.Numero2 };
        }
    }
}
