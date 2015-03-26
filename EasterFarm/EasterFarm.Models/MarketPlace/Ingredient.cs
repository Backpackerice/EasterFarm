namespace EasterFarm.Models.MarketPlace
{
    using EasterFarm.Models.Contracts;

    public class Ingredient : Product, ICookable, IBuyable, IStorable
    {
        public Ingredient(IngredientType name, int price, CurrencyType currency)
            : base(name, price, currency)
        {
        }
    }
}
