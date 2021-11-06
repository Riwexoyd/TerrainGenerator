namespace TerrainGenerator.Models.Implementations
{
    internal sealed class Layer : ILayer
    {
        private readonly float[,] _data;

        public int Height { get; }

        public int Width { get; }

        public Layer(int rows, int columns)
        {
            _data = new float[rows, columns];
            Height = rows;
            Width = columns;
        }

        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= _data.GetLength(0) || column < 0 || column >= _data.GetLength(1))
                {
                    return default;
                }

                return _data[row, column];
            }
            set
            {
                if (row < 0 || row >= _data.GetLength(0) || column < 0 || column >= _data.GetLength(1))
                {
                    return;
                }

                _data[row, column] = value;
            }
        }
    }
}
