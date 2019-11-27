using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Divisao : Operador
    {
        public Divisao(List<object> itensExpressaoMatematica)
        {
            ItensExpressaoMatematica = itensExpressaoMatematica;
            ObterPosicaoOperador(Divisao);
        }

        public override void Resolver()
        {
            while (PosicaoOperador > -1)
            {
                Numero numeroAnterior = ObterNumeroAnteriorAoOperador;
                Numero numeroPosterior = ObterNumeroPosteriorAoOperador;
                Numero = new Numero(numeroAnterior.Valor, numeroPosterior.Valor);
                Numero = Numero / Numero;
                SubstituirExpressao(Numero.Valor);
                InicializarPosicaoOperador();
                ObterPosicaoOperador(Divisao);
            }
        }
    }
}
