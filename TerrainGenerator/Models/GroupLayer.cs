using System.Collections.Generic;

namespace TerrainGenerator.Models
{
    public sealed class GroupLayer : IGroupLayer
    {
        private readonly List<ILayer> _layers = new List<ILayer>();

        public void AddLayer(ILayer layer)
        {
            _layers.Add(layer);
        }

        public void RemoveLayer(ILayer layer)
        {
            _layers.Remove(layer);
        }

        public float this[int row, int column]
        {
            get
            {
                var value = 0f;

                foreach (var layer in _layers)
                {
                    //  TODO: selectable operation
                    value += layer[row, column];
                }

                return value;
            }
        }
    }
}
