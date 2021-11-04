using TerrainGenerator.Generators;

namespace TerrainGenerator.Models
{
    public sealed class GeneratorLayer : ILayer
    {
        private readonly ILayerGenerator _generator;
        private ILayer _layer;

        public GeneratorLayer(ILayerGenerator terrainGenerator)
        {
            _generator = terrainGenerator;
        }

        public float this[int row, int column]
        {
            get
            {
                if (_layer == null)
                {
                    _layer = _generator.Generate();
                }

                return _layer[row, column];
            }
        }
    }
}
