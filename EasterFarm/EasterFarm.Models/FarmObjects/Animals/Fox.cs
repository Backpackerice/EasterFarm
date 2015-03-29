namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;

    public class Fox : Villain, IMovable
    {
        public Fox(MatrixCoords topLeft) 
            : base(topLeft)
        {
        }

        public void StealHen(Hen hen)
        {
            hen.IsDestroyed = true;
        }
    }
}
