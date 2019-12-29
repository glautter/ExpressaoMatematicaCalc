using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressaoCalc.App
{
    public class ExpressaoNumerica
    {
        private const string Espaco = " ";

        private StringBuilder Expressao { get; set; } = new StringBuilder();
        public Agrupador Parentese { get; set; } = new Parentese();
        public Agrupador Colchete { get; set; } = new Colchete();
        public Agrupador Chave { get; set; } = new Chave();
        public StringBuilder ExpressaoPartes { get; set; } = new StringBuilder();

        public ExpressaoNumerica(string expressao)
        {
            Expressao.Append(expressao);

            Parentese.AdicionarExpressao(Expressao.ToString());
        }

        public string RetirarEspacos(string expressao)
        {
            return expressao.Replace(" ", "");
        }

        public StringBuilder ImprimirExpressao
        {
            get { return ExpressaoPartes; }
        }

        public string Resolver()
        {
            var expressaoComEspaco = string.Empty;

            var resultadoParenteses = Parentese.Resolver();
            ExpressaoPartes.AppendLine($"-> {Expressao.ToString()}");
            expressaoComEspaco = FormatarComEspacos(resultadoParenteses);

            ExpressaoPartes.AppendLine($"-> {expressaoComEspaco}");
            Colchete.AdicionarExpressao(resultadoParenteses);

            var resultadoColchetes = Colchete.Resolver();
            if (!resultadoParenteses.Equals(resultadoColchetes))
            {
                expressaoComEspaco = FormatarComEspacos(resultadoColchetes);
                ExpressaoPartes.AppendLine($"-> {expressaoComEspaco}");
            }

            Chave.AdicionarExpressao(resultadoColchetes);
            var resultadoChaves = Chave.Resolver();

            if (!resultadoColchetes.Equals(resultadoChaves))
            {
                expressaoComEspaco = FormatarComEspacos(resultadoChaves);
                ExpressaoPartes.AppendLine($"-> {expressaoComEspaco}");
            }

            var resultadoFinal = new OperacaoMatematica(resultadoChaves.ToString());
            var resultado = resultadoFinal.Calcular();

            ExpressaoPartes.AppendLine($"-> {resultado.ToString()}");

            return $"-> {resultado.ToString()}";
        }

        private bool EhOperador(string caracter)
        {
            return caracter == Operador.Soma || caracter == Operador.Subtracao
                || caracter == Operador.Divisao || caracter == Operador.Multiplicacao;

        }

        private string FormatarComEspacos(string expressaoSemEspaco)
        {
            var expressaoComEspaco = string.Empty;
            var tamanhoCaracteres = expressaoSemEspaco.Length;

            for (int index = 0; index < tamanhoCaracteres; index++)
            {
                expressaoComEspaco += expressaoSemEspaco[index].ToString();

                if ((index == 0 && EhOperador(expressaoSemEspaco[index].ToString())) || EhAgrupamentoAberto(expressaoSemEspaco[index])) continue;
                if (EhOperador(expressaoSemEspaco[index].ToString()) && EhOperador(expressaoSemEspaco[index - 1].ToString())) continue;
                if (EhNumero(expressaoSemEspaco[index]) && EhAgrupamentoFechado(expressaoSemEspaco[index])) continue;
                if (EhNumero(expressaoSemEspaco[index]) && tamanhoCaracteres > index + 1 && (EhNumero(expressaoSemEspaco[index + 1])
                    || EhAgrupamentoFechado(expressaoSemEspaco[index + 1]))) continue;

                expressaoComEspaco += Espaco;
            }

            return expressaoComEspaco;
        }

        private bool EhNumero(char caracter)
        {
            return char.IsDigit(caracter);
        }

        private bool EhAgrupamentoFechado(char caracterExpressao)
        {
            return Parentese.AgrupadorFechado == caracterExpressao.ToString() ||
                                Colchete.AgrupadorFechado == caracterExpressao.ToString() ||
                                Chave.AgrupadorFechado == caracterExpressao.ToString();
        }

        private bool EhAgrupamentoAberto(char caracterExpressao)
        {
            return Parentese.AgrupadorAberto == caracterExpressao.ToString() ||
                                Colchete.AgrupadorAberto == caracterExpressao.ToString() ||
                                Chave.AgrupadorAberto == caracterExpressao.ToString();
        }
    }
}
