using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Multiplicacao : Operador
    {
        public Multiplicacao(List<object> itensExpressaoMatematica)
        {
            ItensExpressaoMatematica = itensExpressaoMatematica;
            Indexador = itensExpressaoMatematica.IndexOf(Multiplicacao);
        }

        public override void Resolver()
        {
            if (Indexador > -1)
            {
                Numero numeroAnterior = ObterNumeroAnteriorAoOperador;
                Numero numeroPosterior = ObterNumeroPosteriorAoOperador;
                Numero = new Numero(numeroAnterior.Valor, numeroPosterior.Valor);
                Numero = Numero * Numero;
                SubstituirExpressao(Numero.Valor);
            }
        }       

    }
}
