using System;

using TerrainGenerator.Models;
using TerrainGenerator.Models.Implementations.TerrainLayerGenerators;

namespace TerrainGenerator.Builders
{
    public sealed class DiamondSquareLayerBuilder : LayerGeneratorBaseBuilder<DiamondSquareLayerGenerator>
    {
        public DiamondSquareLayerBuilder(TerrainGeneratorBuilder builder, IOperation operation) : base(builder, operation)
        {
        }

        public DiamondSquareLayerBuilder SetRoughness(float value)
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 1");
            }

            _layerGenerator.Roughness = value;
            return this;
        }
    }
}
