namespace EasterFarm.Models.PresentFactory.Presents
{
    using EasterFarm.Models.Market;

    public class RabbitWithRibbon : Present
    {
        private const int BasketAmmount = 1;
        private const int RabbitAmmount = 1;
        private const int RibbonAmmount = 1;

        public RabbitWithRibbon(FarmManager producer)
            : base(PresentType.RabbitWithRibbon, (int)PresentType.RabbitWithRibbon, MarketCurrency.Raspberries, producer)
        {
        }

        public override void SetIngredients()
        {
            this.NeededIngredients.Add(IngredientType.Ribbon, RibbonAmmount);
            this.NeededIngredients.Add(IngredientType.Basket, BasketAmmount);
            this.NeededIngredients.Add(IngredientType.Rabbit, RabbitAmmount);
        }
    }
}
