using System;

namespace TerrainGenerator.Models
{
    public interface ITerrainLayerGenerator
    {
        ILayer GenerateLayer(int width, int height, Random random);
    }
}
