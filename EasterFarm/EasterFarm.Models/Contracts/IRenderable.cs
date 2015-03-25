namespace EasterFarm.Models.Contracts
{
    public interface IRenderable
    {
        MatrixCoords TopLeft { get; }

        // TODO : more abstract object?
        char[,] Image { get; }
    }
}
