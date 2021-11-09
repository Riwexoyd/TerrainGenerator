using System;

using TerrainGenerator.Models;

namespace TerrainGenerator.Helpers
{
    internal static class MathHelper
    {
        public static float GetEuclidDistance(Vector2 first, Vector2 second)
        {
            return (float)Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
        }

        public static float GetManhattanDistance(Vector2 first, Vector2 second)
        {
            return Math.Abs(second.X - first.X) + Math.Abs(second.Y - first.Y);
        }

        public static float GetMaximumDistance(Vector2 first, Vector2 second)
        {
            return Math.Max(Math.Abs(second.X - first.X), Math.Abs(second.Y - first.Y));
        }
    }
}
