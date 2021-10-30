namespace TerrainGenerator.Models
{
    public sealed class Layer : ILayer
    {
        private readonly float[,] _data;

        public Layer(int rows, int columns)
        {
            _data = new float[rows, columns];
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
