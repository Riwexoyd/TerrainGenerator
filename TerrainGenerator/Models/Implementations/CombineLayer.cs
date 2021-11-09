using System;

namespace TerrainGenerator.Models.Implementations
{
    internal class CombineLayer : ILayer
    {
        private readonly ILayer _first;
        private readonly ILayer _second;
        private readonly Func<float, float, float> combineFunc;

        public CombineLayer(ILayer first, ILayer second, Func<float, float, float> combineFunc)
        {
            _first = first;
            _second = second;
            this.combineFunc = combineFunc;
        }

        public float this[int row, int column] => combineFunc(_first[row, column], _second[row, column]);

        public int Height => _first.Height;

        public int Width => _first.Width;
    }
}
