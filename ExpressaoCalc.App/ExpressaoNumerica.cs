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

        public StringBuilder Resolver(Notacao notacao)
        {
            var expressaoNumerica = new StringBuilder();
            expressaoNumerica.AppendLine(Parentese.Resolver(Expressao.ToString()));

            return expressaoNumerica;
        }

        
    }
}
