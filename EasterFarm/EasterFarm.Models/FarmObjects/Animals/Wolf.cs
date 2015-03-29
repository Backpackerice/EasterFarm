namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;

    public class Wolf : Villain, IMovable
    {
        private static char[,] image = new char[,] {{'╪'}};

        public Wolf(MatrixCoords topLeft) 
            : base(topLeft)
        {
        }

        public void StealLamb(Lamb lamb)
        {
            lamb.IsDestroyed = true;
        }
    }
}
