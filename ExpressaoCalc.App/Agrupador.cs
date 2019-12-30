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
                ResolverOperadoresMultiplos();

                var expressaoMinimaEncontrada = ObterExpressaoComAgrupadorQueDeveSerResolvidaPrimeiro;
                var operacaoMatematica = new OperacaoMatematica(expressaoMinimaEncontrada.Value);

                var valorCalculado = operacaoMatematica.Calcular();
                Expressao.Replace(expressaoMinimaEncontrada.Value, valorCalculado.ToString());
            }

            return Expressao.ToString();
        }

        private void ResolverOperadoresMultiplos()
        {
            var operador = string.Empty;
            string operadorMultiplo = string.Empty;

            for (int index = 0; index < ObterOperadoresMultiplos.Count; index++)
            {
                var operadores = ObterOperadoresMultiplos[index].ToString();
                if (operadores.ToString().Length == 1) continue;

                foreach (var itemOperador in operadores)
                {
                    if (itemOperador.ToString() == Operador.Multiplicacao || itemOperador.ToString() == Operador.Divisao)
                    {
                        operadores = operadores.Replace(itemOperador.ToString(), "");
                        continue;
                    }

                    operador = string.IsNullOrWhiteSpace(operador) ? itemOperador.ToString() :
                    (operador == Operador.Soma && itemOperador.ToString() == Operador.Soma ? Operador.Soma :
                    (operador == Operador.Subtracao && itemOperador.ToString() == Operador.Subtracao ? Operador.Soma :
                    (operador == Operador.Soma && itemOperador.ToString() == Operador.Subtracao ? Operador.Subtracao :
                    (operador == Operador.Subtracao && itemOperador.ToString() == Operador.Soma ? Operador.Subtracao : operador + itemOperador.ToString()))));
                }
                operadorMultiplo = operadores.ToString();
                Expressao.Replace(operadorMultiplo, operador);
                operador = string.Empty;
            }
        }

        private MatchCollection ObterOperadoresMultiplos
        {
            get
            {
                return Regex.Matches(Expressao.ToString(), "(([\\-\\+\\*\\/\\s])+)");
            }
        }

        private Match ObterExpressaoComAgrupadorQueDeveSerResolvidaPrimeiro
        {
            get { return Regex.Matches(Expressao.ToString(), $"\\{AgrupadorAberto}((?:[^\\{AgrupadorAberto}\\{AgrupadorFechado}])*)\\{AgrupadorFechado}")[0]; }
        }

        public void AdicionarExpressao(string expressao)
        {
            expressao = expressao.ToString().Replace(" ", "");
            Expressao.Append(expressao);
        }

        public bool TemAgrupador
        {
            get { return Expressao.ToString().IndexOf(AgrupadorAberto) > -1; }
        }
    }
}
