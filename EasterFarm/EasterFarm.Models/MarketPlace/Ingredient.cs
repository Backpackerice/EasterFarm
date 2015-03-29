namespace EasterFarm.Models.MarketPlace
{
    using EasterFarm.Models.Contracts;

    public class Ingredient : Product, ICookable, IBuyable, IStorable
    {
        public Ingredient(IngredientType type, Category category, int price)
            : base(type, category, price)
        {
        }
    }
}
