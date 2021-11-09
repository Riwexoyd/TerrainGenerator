using System;

using TerrainGenerator.Extensions;

namespace TerrainGenerator.Models.Implementations.TerrainLayerGenerators
{
    internal sealed class DiamondSquareLayerGenerator : ITerrainLayerGenerator
    {
        public float Roughness { get; set; } = 0.5f;

        public ILayer GenerateLayer(int width, int height, Random random)
        {
            var layer = new Layer(height, width);
            SetVertexRandomValue(layer, random);
            float range = 1;
            for (int length = Math.Min(layer.Width, layer.Height) - 1; length > 1; length /= 2)
            {
                for (int y = 0; y < layer.Height - 1; y += length)
                {
                    for (int x = 0; x < layer.Width - 1; x += length)
                    {
                        int mid = length / 2;
                        Diamond(random, layer, x, y, x + length, y + length, mid, range);
                        Square(random, layer, x, y + mid, mid, range);
                        Square(random, layer, x + length, y + mid, mid, range);
                        Square(random, layer, x + mid, y + length, mid, range);
                        Square(random, layer, x + mid, y, mid, range);
                    }
                }

                range *= Roughness;
            }

            return layer;
        }

        private void Diamond(Random random, Layer layer, int leftX, int leftY, int rightX, int rightY, int mid, float r)
        {
            layer[leftY + mid, leftX + mid] = (layer[rightY, rightX] + layer[leftY, leftX] + layer[rightY, leftX]
                + layer[leftY, rightX]) * 0.25f + random.NextRange(r);
        }

        private void Square(Random random, Layer layer, int x, int y, int mid, float r)
        {
            layer[y, x] = (layer[y, x - mid] + layer[y, x + mid]
                    + layer[y + mid, x] + layer[y - mid, x]) * 0.25f + random.NextRange(r);
        }

        private void SetVertexRandomValue(Layer layer, Random random)
        {
            for (int y = 0; y < layer.Height; y += layer.Height - 1)
            {
                for (int x = 0; x < layer.Width; x += layer.Width - 1)
                {
                    layer[y, x] = 0.5f + random.NextRange(0.5f);
                }
            }
        }
    }
}
