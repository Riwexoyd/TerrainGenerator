namespace TerrainGenerator.Models.Implementations
{
    internal sealed class Terrain : ITerrain
    {
        private readonly ILayer _layer;

        public int Height => _layer.Height;

        public int Width => _layer.Width;

        public Terrain(ILayer layer)
        {
            _layer = layer;
        }

        public float this[int row, int column]
        {
            get
            {
                return _layer[row, column];
            }
        }

        public float[,] GetHeightMap()
        {
            var result = new float[Height, Width];
            for (var y = 0; y < Height; ++y)
            {
                for (var x = 0; x < Width; ++x)
                {
                    result[y, x] = _layer[x, y];
                }
            }

            return result;
        }
    }
}
