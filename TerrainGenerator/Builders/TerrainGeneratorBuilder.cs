using System;

using TerrainGenerator.Models;
using TerrainGenerator.Models.Implementations;

namespace TerrainGenerator.Builders
{
    public class TerrainGeneratorBuilder
    {
        private readonly TerrainGeneratorInternal terrainGenerator;

        public TerrainGeneratorBuilder()
        {
            terrainGenerator = new TerrainGeneratorInternal();
        }

        public TerrainGeneratorBuilder SetSize(int width, int height)
        {
            if (width % 2 != 0 || height % 2 != 0)
            {
                throw new ArgumentException("Width and Height must be divisible by 2");
            }

            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be greater than 0");
            }

            terrainGenerator.Columns = width;
            terrainGenerator.Rows = height;

            return this;
        }

        public TerrainGeneratorBuilder SetSeed(int seed)
        {
            terrainGenerator.Seed = seed;

            return this;
        }

        public TerrainGeneratorBuilder AddLayer(ITerrainLayerGenerator layer, IOperation operation)
        {
            terrainGenerator.TerrainGeneratorLayers.Add((layer, operation));

            return this;
        }

        public TerrainGeneratorBuilder RemoveLayer(ITerrainLayerGenerator layer)
        {
            for (var i = 0; i < terrainGenerator.TerrainGeneratorLayers.Count; ++i)
            {
                if (terrainGenerator.TerrainGeneratorLayers[i].generator.Equals(layer))
                {
                    terrainGenerator.TerrainGeneratorLayers.RemoveAt(i);
                    break;
                }
            }

            return this;
        }

        public ITerrainGenerator Build()
        {
            return terrainGenerator;
        }
    }
}
