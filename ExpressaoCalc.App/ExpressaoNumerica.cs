using System.Collections.Generic;
using System.Text;

namespace ExpressaoCalc.App
{
    public class ExpressaoNumerica
    {
        public Numero Numero { get; set; }
        public Operador Operador { get; set; }
        private StringBuilder Expressao { get; set; } = new StringBuilder();
        public Sinal Parentese { get; set; } = new Parentese();
        public Sinal Colchete { get; set; } = new Colchete();
        public Sinal Chave { get; set; } = new Chave();

        public ExpressaoNumerica(string expressao)
        {
            AdicionarExpressao(expressao);
        }

        private void AdicionarExpressao(string expressao)
        {
            Expressao.Append(expressao);
        }

        public string RetirarEspacos(string expressao)
        {
            return expressao.Replace(" ", "");
        }

        public StringBuilder Resolver()
        {
            var resultadoParenteses = new StringBuilder(Parentese.Resolver(Expressao.ToString()));
            var resultadoColchetes = new StringBuilder(Colchete.Resolver(resultadoParenteses.ToString()));
            var resultadoChaves = new StringBuilder(Chave.Resolver(resultadoColchetes.ToString()));

            return resultadoChaves;
        }

        
    }
}
