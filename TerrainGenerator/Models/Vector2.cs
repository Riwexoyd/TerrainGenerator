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
    }
}
