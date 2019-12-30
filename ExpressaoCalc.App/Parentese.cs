namespace ExpressaoCalc.App
{
    public class Parentese : Agrupador
    {
        public override string AgrupadorAberto { get => "("; }
        public override string AgrupadorFechado { get => ")"; }
    }
}
