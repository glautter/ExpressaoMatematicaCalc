using System;
using ExpressaoCalc.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressaoCalc.Test
{
    [TestClass]
    public class CalculoExpressaoTest
    {
        private readonly string ExpressaoComParenteses = "3 * (2 + 5)";
        private readonly string ExpressaoComDoisParenteses = "3 * ((2 + 5) + 5)";
        private readonly string ExpressaoComTresParentesesUmColcheteUmaChave = "8116 / {1 + [3 * (4 * (45 + 90)) + (8 - 5)] * 5}";
        private readonly string ExpressaoComParentesesValorNegativo = "-2 * {1 + [3 * (4 * (45 + 90)) + ((-8) - 5)] * 5}";
        private readonly string ExpressaoComMultiplosOperadoresNegativos = "--2 * {1 --+ [3 * (4 * (45 ++-- 90)) + ((-----8) -- 5)] * 5}";
        private readonly string ExpressaoComParentesesSemEspaco = "3*(2+5)";
        private readonly string ExpressaoComMultiplicacaoDeValorNegativo = "3 * (2 - 5)";
        private readonly string ExpressaoComplexa = "+++++--2 * {1 -++-+-+-+ [3 * (4 * (45 ++-- 90)) + ((-----+-+-+-+-+-+-+-8) -- 5)] * ---+++5}";
        private readonly string ExpressaoSoComDivisaoDeValorNegativo = "450 / (10 - 15) * (-9)";
        private ExpressaoNumerica ExpressaoMatematica { get; set; }
        

        [TestMethod]
        public void DeveObterParenteseAberto()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.AgrupadorAberto == "(");
        }

        [TestMethod]
        public void DeveObterParenteseFechado()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.AgrupadorFechado == ")");
        }

        [TestMethod]
        public void DeveIdentificarSeTemAgrupador()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.TemAgrupador);
        }

        [TestMethod]
        public void DeveRetirarOsEspacos()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.RetirarEspacos(ExpressaoComParenteses) == ExpressaoComParentesesSemEspaco);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsParenteses()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParenteses);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "3*7") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsDoisParenteses()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComDoisParenteses);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "3*12") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComResultado21()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParenteses);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 21") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoSoComParentesesSemEspaco()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParentesesSemEspaco);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 21") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComMultiplicacaoComValorNegativo()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComMultiplicacaoDeValorNegativo);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> -9") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComDivisaoComValorNegativo()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComDivisaoDeValorNegativo);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 10") == 0);
        }
        

        [TestMethod]
        public void DeveResolverAExpressaoComParentesesValorNegativo()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComParentesesValorNegativo);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> -16072") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComMultiplosOperadoresNegativos()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComMultiplosOperadoresNegativos);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 16172") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComplexa()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComplexa);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> -16328") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsTresParentesesUmColcheteUmaChave()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoComTresParentesesUmColcheteUmaChave);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "8116/{1+[3*540+3]*5}") == 0);
            ExpressaoMatematica.Colchete.AdicionarExpressao(ExpressaoMatematica.Parentese.Expressao.ToString());
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Colchete.Resolver(), "8116/{1+1623*5}") == 0);
            ExpressaoMatematica.Chave.AdicionarExpressao(ExpressaoMatematica.Colchete.Expressao.ToString());
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Chave.Resolver(), "8116/8116") == 0);
            var resultadoFinal = new OperacaoMatematica(ExpressaoMatematica.Chave.Expressao.ToString());
            Assert.AreEqual(resultadoFinal.Calcular(), 1);
        }
    }
}
