namespace ExpressaoCalc.App
{
    public class Colchete : Agrupador
    {
        public override string AgrupadorAberto { get => "["; }
        public override string AgrupadorFechado { get => "]"; }
    }
}
