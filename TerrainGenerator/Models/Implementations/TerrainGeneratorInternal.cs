using System.Collections.Generic;

namespace TerrainGenerator.Models.Implementations
{
    internal sealed class TerrainGeneratorInternal : ITerrainGenerator
    {
        public int Columns { get; set; }

        public int Rows { get; set; }

        public int Seed { get; set; }

        public List<ITerrainLayerGenerator> TerrainGeneratorLayers { get; } = new List<ITerrainLayerGenerator>();

        public ITerrain Generate()
        {
            throw new System.NotImplementedException();
        }
    }
}
