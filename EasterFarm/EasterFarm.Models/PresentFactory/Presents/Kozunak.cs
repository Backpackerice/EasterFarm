namespace EasterFarm.Models.PresentFactory.Presents
{
    using EasterFarm.Models.Market;

    public class Kozunak : Present
    {
        private const int EggsAmmount = 2;
        private const int FlourAmmount = 1;
        private const int BasketAmmount = 1;

        public Kozunak(FarmManager producer)
            : base(PresentType.Kozunak, (int)PresentType.Kozunak, MarketCurrency.Blueberries, producer)
        {
        }

        public override void SetIngredients()
        {
            this.NeededIngredients.Add(IngredientType.Egg, EggsAmmount);
            this.NeededIngredients.Add(IngredientType.Flour, FlourAmmount);
            this.NeededIngredients.Add(IngredientType.Basket, BasketAmmount);
        }
    }
}
