using System;
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
            Parentese.AdicionarExpressao(expressao);
        }

        private void AdicionarExpressao(string expressao)
        {
            Expressao.Append(expressao);
        }

        public string RetirarEspacos(string expressao)
        {
            return expressao.Replace(" ", "");
        }

        public string Resolver()
        {
            var resultadoParenteses = Parentese.Resolver();
            Console.WriteLine($"-> {resultadoParenteses}");
            Colchete.AdicionarExpressao(resultadoParenteses);
            var resultadoColchetes = Colchete.Resolver();
            if (!resultadoParenteses.Equals(resultadoColchetes))
                Console.WriteLine($"-> {resultadoColchetes}");
            Chave.AdicionarExpressao(resultadoColchetes);
            var resultadoChaves = Chave.Resolver();
            if (!resultadoColchetes.Equals(resultadoChaves))
                Console.WriteLine($"-> {resultadoChaves}");
            var resultadoFinal = new OperacaoMatematica(resultadoChaves.ToString(), "", "");
            var resultado = resultadoFinal.Calcular();

            return $"-> {resultado.ToString()}";
        }

        
    }
}
