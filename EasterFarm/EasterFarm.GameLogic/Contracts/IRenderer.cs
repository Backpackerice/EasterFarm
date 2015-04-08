namespace EasterFarm.GameLogic.Contracts
{
    using System.Collections.Generic;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.Presents;

    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);

        void RenderAll();

        void RenderPresentFactory(IDictionary<IStorable, int> presents);

        void RenderMarket(ICollection<IBuyable> proucts);

        void RenderGameOver();

        void ClearRenderer();
    }
}
