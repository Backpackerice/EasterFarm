namespace EasterFarm.Models.Contracts
{
    public interface IRenderable
    {
        MatrixCoords TopLeft { get; }

        char[,] Image { get; }
    }
}
