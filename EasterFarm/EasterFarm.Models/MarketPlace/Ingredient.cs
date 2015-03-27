namespace EasterFarm.Models.MarketPlace
{
    using EasterFarm.Models.Contracts;

    public class Ingredient : Product, ICookable, IBuyable, IStorable
    {
        public Ingredient(IngredientType name, Category category, int price)
            : base(name, category, price)
        {
        }
    }
}
