using System;
using ExpressaoCalc.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressaoCalc.Test
{
    [TestClass]
    public class CalculoExpressaoTest
    {
        private readonly string ExpressaoSoComParenteses = "3 * (2 + 5)";
        private readonly string ExpressaoSoComDoisParenteses = "3 * ((2 + 5) + 5)";
        private readonly string ExpressaoSoComTresParentesesUmColcheteUmaChave = "8116 / {1 + [3 * (4 * (45 + 90)) + (8 - 5)] * 5}";
        private readonly string ExpressaoSoComParentesesValorNegativo = "2 * {1 + [3 * (4 * (45 + 90)) + ((-8) - 5)] * 5}";
        private readonly string ExpressaoSoComParentesesSemEspaco = "3*(2+5)";
        private ExpressaoNumerica ExpressaoMatematica { get; set; }
        

        [TestMethod]
        public void DeveObterParenteseAberto()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.AgrupadorAberto == "(");
        }

        [TestMethod]
        public void DeveObterParenteseFechado()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.AgrupadorFechado == ")");
        }

        [TestMethod]
        public void DeveIdentificarSeTemAgrupador()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.TemAgrupador);
        }

        [TestMethod]
        public void DeveRetirarOsEspacos()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.RetirarEspacos(ExpressaoSoComParenteses) == ExpressaoSoComParentesesSemEspaco);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsParenteses()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "3 * 7") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsDoisParenteses()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComDoisParenteses);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "3 * 12") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComResultado21()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 21") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoSoComParentesesSemEspaco()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParentesesSemEspaco);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 21") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComParentesesValorNegativo()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParentesesValorNegativo);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 0") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsTresParentesesUmColcheteUmaChave()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComTresParentesesUmColcheteUmaChave);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "8116 / {1 + [3 * 540 + 3] * 5}") == 0);
            ExpressaoMatematica.Colchete.AdicionarExpressao(ExpressaoMatematica.Parentese.Expressao.ToString());
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Colchete.Resolver(), "8116 / {1 + 1623 * 5}") == 0);
            ExpressaoMatematica.Chave.AdicionarExpressao(ExpressaoMatematica.Colchete.Expressao.ToString());
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Chave.Resolver(), "8116 / 8116") == 0);
            var resultadoFinal = new OperacaoMatematica(ExpressaoMatematica.Chave.Expressao.ToString());
            Assert.AreEqual(resultadoFinal.Calcular(), 1);
        }
    }
}
