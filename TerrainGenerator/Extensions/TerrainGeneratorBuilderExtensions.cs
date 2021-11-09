using TerrainGenerator.Builders;
using TerrainGenerator.Models;

namespace TerrainGenerator.Extensions
{
    public static class TerrainGeneratorBuilderExtensions
    {
        public static DiamondSquareLayerBuilder AddDiamondSquare(this TerrainGeneratorBuilder builder, IOperation operation)
        {
            return new DiamondSquareLayerBuilder(builder, operation);
        }

        public static WorleyNoiseLayerBuilder AddWorleyNoise(this TerrainGeneratorBuilder builder, IOperation operation)
        {
            return new WorleyNoiseLayerBuilder(builder, operation);
        }
    }
}
