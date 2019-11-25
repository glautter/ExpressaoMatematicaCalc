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
        public int NumeroAnterior { get; set; }
        public int NumeroPosterior { get; set; }

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
            return new Numero { Valor = c.NumeroAnterior -c.NumeroPosterior };
        }
        public static Numero operator +(Numero c)
        {
            return new Numero { Valor = c.NumeroAnterior +c.NumeroPosterior };
        }
        public static Numero operator *(Numero c, Numero d)
        {
           return new Numero { Valor = c.NumeroAnterior * d.NumeroPosterior };
        }
        public static Numero operator /(Numero c, Numero b)
        {
            return new Numero { Valor = c.NumeroAnterior / b.NumeroPosterior };
        }

        public void AtribuirValor(int valor)
        {
            Valor = valor;
        }

        public bool EhNumerico(string caracter)
        {
            return int.TryParse(caracter.ToString(), out _);
        }

        public void ConcatenarValor(string caracter)
        {
            if (!string.IsNullOrWhiteSpace(caracter) && EhNumerico(caracter))
                Valor = int.Parse(Valor.ToString() + caracter);
        }
        public bool ValorZerado { get { return Valor == 0; } }
    }
}
