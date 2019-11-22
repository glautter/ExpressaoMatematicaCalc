using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Soma : Operador
    {
        public Soma(List<object> itensExpressaoMatematica)
        {
            ItensExpressaoMatematica = itensExpressaoMatematica;
            Indexador = itensExpressaoMatematica.IndexOf("+");
        }

        public override void Resolver()
        {
            if (Indexador > -1)
            {
                Numero numero1 = ObterNumeroAnteriorAoOperador;
                Numero numero2 = ObterNumeroPosteriorAoOperador;
                Numero numeroOperador = new Numero(numero1.Valor, numero2.Valor);
                numeroOperador = +numeroOperador;
                Resultado = numeroOperador.Valor;
            }
        }
    }
}
