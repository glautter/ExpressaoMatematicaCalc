using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressaoCalc.App
{
    public class ExpressaoNumerica
    {
        private StringBuilder Expressao { get; set; } = new StringBuilder();
        public Agrupador Parentese { get; set; } = new Parentese();
        public Agrupador Colchete { get; set; } = new Colchete();
        public Agrupador Chave { get; set; } = new Chave();

        public ExpressaoNumerica(string expressao)
        {
            Expressao.Append(expressao);

            Parentese.AdicionarExpressao(Expressao.ToString());
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
            var resultadoFinal = new OperacaoMatematica(resultadoChaves.ToString());
            var resultado = resultadoFinal.Calcular();

            return $"-> {resultado.ToString()}";
        }

        
    }
}
