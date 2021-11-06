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
    }
}
