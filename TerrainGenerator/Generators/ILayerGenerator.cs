using TerrainGenerator.Models;

namespace TerrainGenerator.Generators
{
    public interface ILayerGenerator
    {
        ILayer Generate();
    }
}
