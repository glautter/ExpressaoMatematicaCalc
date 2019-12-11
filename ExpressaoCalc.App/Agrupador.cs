using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressaoCalc.App
{
    public abstract class Agrupador
    {
        public virtual string AgrupadorAberto { get; set; }
        public virtual string AgrupadorFechado { get; set; }
        public StringBuilder Expressao { get; set; } = new StringBuilder();

        public string Resolver()
        {
            while (TemAgrupador)
            {
                var expressaoMinimaEncontrada = ObterExpressaoComAgrupadorQueDeveSerResolvidaPrimeiro;
                var operacaoMatematica = new OperacaoMatematica(expressaoMinimaEncontrada.Value);
                Expressao.Replace(expressaoMinimaEncontrada.Value, operacaoMatematica.Calcular().ToString());
            }

            return Expressao.ToString();
        }

        private Match ObterExpressaoComAgrupadorQueDeveSerResolvidaPrimeiro
        {
            get { return Regex.Matches(Expressao.ToString(), $"\\{AgrupadorAberto}((?:[^\\{AgrupadorAberto}\\{AgrupadorFechado}])*)\\{AgrupadorFechado}")[0]; }
        }

        public void AdicionarExpressao(string expressao)
        {
            Expressao.Append(expressao);
        }

        private IList<int> ObterPosicoesDoAgrupador(string agrupador)
        {
            var posicoes = new List<int>();

            for (int index = 0; index < Expressao.Length; index++)
            {
                if (Expressao[index].ToString().Equals(agrupador))
                {
                    posicoes.Add(index);
                }
            }

            return posicoes;
        }

        public bool TemAgrupador
        {
            get { return Expressao.ToString().IndexOf(AgrupadorAberto) > -1; }
        }
    }
}
