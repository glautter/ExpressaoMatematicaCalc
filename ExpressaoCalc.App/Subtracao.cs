using System.Collections.Generic;

namespace ExpressaoCalc.App
{
    public class Subtracao : Operador
    {
        public Subtracao(List<object> itensExpressaoMatematica)
        {
            ItensExpressaoMatematica = itensExpressaoMatematica;
            ObterPosicaoOperador(Subtracao);
        }

        public override void Resolver()
        {
            while (PosicaoOperador > -1)
            {
                Numero = ObterNumerosAnteriorEPosterior;
                Numero = -Numero;
                SubstituirExpressao(Numero.Valor);

                InicializarPosicaoOperador();
                ObterPosicaoOperador(Subtracao);
            }
        }
    }
}
