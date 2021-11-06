using System;
using System.Collections.Generic;

namespace TerrainGenerator.Models.Implementations
{
    internal sealed class TerrainGeneratorInternal : ITerrainGenerator
    {
        public int Columns { get; set; }

        public int Rows { get; set; }

        public int Seed { get; set; }

        public List<(ITerrainLayerGenerator generator, IOperation operation)> TerrainGeneratorLayers { get; } = new List<(ITerrainLayerGenerator, IOperation)>();

        public ITerrain Generate()
        {
            var random = new Random(Seed);
            ILayer currentLayer = new Layer(Rows, Columns);
            foreach (var (generator, operation) in TerrainGeneratorLayers)
            {
                var layer = generator.GenerateLayer(Columns, Rows, random);
                currentLayer = operation.Execute(currentLayer, layer);
            }
            var terrain = new Terrain(currentLayer);
            return terrain;
        }
    }
}
