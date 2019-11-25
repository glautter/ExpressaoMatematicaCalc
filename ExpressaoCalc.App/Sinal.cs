using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public abstract class Sinal
    {
        public virtual string SinalAberto { get; set; }
        public virtual string SinalFechado { get; set; }
        public StringBuilder Expressao { get; set; } = new StringBuilder();

        public string Resolver(string expressao)
        {
            AdicionarExpressao(expressao);

            if (TemSinal)
            {
                var matches = Regex.Matches(expressao, $"\\{SinalAberto}(.*?)\\{SinalFechado}");
                foreach (Match match in matches)
                {
                    var operacaoMatematica = new OperacaoMatematica(match.Value, SinalAberto, SinalFechado);
                    Expressao.Replace(match.Value, operacaoMatematica.Calcular().ToString());
                }
            }

            return Expressao.ToString();
        }

        public void AdicionarExpressao(string expressao)
        {
            Expressao.Append(expressao);
        }

        private IList<int> ObterPosicoesDoSinal(string sinal)
        {
            var posicoes = new List<int>();

            for (int index = 0; index < Expressao.Length; index++)
            {
                if (Expressao[index].ToString().Equals(sinal))
                {
                    posicoes.Add(index);
                }
            }

            return posicoes;
        }

        public bool TemSinal
        {
            get { return Expressao.ToString().IndexOf(SinalAberto) > -1; }
        }
    }
}
