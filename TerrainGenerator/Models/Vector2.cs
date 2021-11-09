using System;

namespace TerrainGenerator.Models
{
    internal struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static float operator *(Vector2 first, Vector2 second)
        {
            return first.X * second.X + first.Y * second.Y;
        }

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
