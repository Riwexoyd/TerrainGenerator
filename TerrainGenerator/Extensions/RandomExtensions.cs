using System;

namespace TerrainGenerator.Extensions
{
    public static class RandomExtensions
    {
        public static float NextPlusMinusOne(this Random random) => (float)(2 * random.NextDouble() - 1);

        public static float NextRange(this Random random, float range) => NextPlusMinusOne(random) * range;
    }
}
