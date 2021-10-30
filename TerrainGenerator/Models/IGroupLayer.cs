namespace TerrainGenerator.Models
{
    public interface IGroupLayer : ILayer
    {
        void AddLayer(ILayer layer);

        void RemoveLayer(ILayer layer);
    }
}
