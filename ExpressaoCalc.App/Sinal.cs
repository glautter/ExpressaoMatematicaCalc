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

        public string Resolver()
        {
            //AdicionarExpressao(expressao);

            while (TemSinal)
            {
                var expressaoMinimaEncontrada = ObterExpressaoComSinalQueDeveSerResolvidaPrimeiro;
                var operacaoMatematica = new OperacaoMatematica(expressaoMinimaEncontrada.Value, SinalAberto, SinalFechado);
                Expressao.Replace(expressaoMinimaEncontrada.Value, operacaoMatematica.Calcular().ToString());
            }

            return Expressao.ToString();
        }

        private Match ObterExpressaoComSinalQueDeveSerResolvidaPrimeiro
        {
            ////\(((?:[^])*)\)
            get { return Regex.Matches(Expressao.ToString(), $"\\{SinalAberto}((?:[^{SinalFechado}])*)\\{SinalFechado}")[0]; }
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
