using System;

namespace ExpressaoCalc.App
{
    public class Numero
    {
        public int Valor { get; set; }
        public static int NumeroAnterior { get; set; }
        public static int NumeroPosterior { get; set; }

        public Numero() { }
        public Numero(int valor)
        {
            Valor = valor;
        }

        public Numero(int numeroAnterior, int numeroPosterior)
        {
            NumeroAnterior = numeroAnterior;
            NumeroPosterior = numeroPosterior;
        }

        public static Numero operator -(Numero c)
        {
            return new Numero { Valor = NumeroAnterior - NumeroPosterior };
        }

        public static Numero operator +(Numero c) => new Numero { Valor = NumeroAnterior + NumeroPosterior };
        public static Numero operator *(Numero c, Numero d) => new Numero { Valor = NumeroAnterior * NumeroPosterior };
        public static Numero operator /(Numero c, Numero b) => new Numero { Valor = NumeroAnterior / NumeroPosterior };

        public void AtribuirValor(int valor)
        {
            Valor = valor;
        }

        public bool EhNumerico(string caracter)
        {
            return int.TryParse(caracter.ToString(), out _);
        }
    }
}
