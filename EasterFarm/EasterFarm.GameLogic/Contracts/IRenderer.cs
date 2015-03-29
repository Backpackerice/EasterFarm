namespace EasterFarm.GameLogic.Contracts
{
    using EasterFarm.Models.Contracts;

    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);

        void RenderAll();

        void ClearRenderer();
    }
}
