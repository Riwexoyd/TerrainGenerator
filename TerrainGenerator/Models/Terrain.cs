namespace TerrainGenerator.Models
{
    public sealed class Terrain : ITerrain, IGroupLayer
    {
        private readonly IGroupLayer _groupLayer;

        public int Height { get; }

        public int Width { get; }

        public Terrain(int rows, int columns)
        {
            Height = rows;
            Width = columns;
            _groupLayer = new GroupLayer();
        }

        public void AddLayer(ILayer layer)
        {
            _groupLayer.AddLayer(layer);
        }

        public void RemoveLayer(ILayer layer)
        {
            _groupLayer.RemoveLayer(layer);
        }

        public float this[int row, int column] => _groupLayer[row, column];
    }
}
