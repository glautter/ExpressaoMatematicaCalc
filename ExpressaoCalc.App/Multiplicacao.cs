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
            ObterPosicaoOperador(Multiplicacao);
        }

        public override void Resolver()
        {
            while (PosicaoOperador > -1)
            {
                Numero = ObterNumerosAnteriorEPosterior;
                Numero *= Numero;
                SubstituirExpressao(Numero.Valor);

                InicializarPosicaoOperador();
                ObterPosicaoOperador(Multiplicacao);
            }
        }       

    }
}
