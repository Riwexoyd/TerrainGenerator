using System;

namespace TerrainGenerator.Extensions
{
    public static class RandomExtensions
    {
        public static float GetRandomFloat(this Random random) => (float)(2 * random.NextDouble() - 1);

        public static float GetRange(this Random random, float range) => GetRandomFloat(random) * range;
    }
}
