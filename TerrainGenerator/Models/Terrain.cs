namespace TerrainGenerator.Models
{
    public sealed class Terrain : ITerrain
    {
        private readonly IGroupLayer _groupLayer;

        public int Rows { get; }

        public int Columns { get; }

        public Terrain(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
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
