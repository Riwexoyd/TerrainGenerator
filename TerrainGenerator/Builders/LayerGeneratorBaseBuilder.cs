using TerrainGenerator.Models;

namespace TerrainGenerator.Builders
{
    public abstract class LayerGeneratorBaseBuilder<T> where T: ITerrainLayerGenerator, new()
    {
        private readonly TerrainGeneratorBuilder _builder;
        protected readonly T _layerGenerator;

        public LayerGeneratorBaseBuilder(TerrainGeneratorBuilder builder, IOperation operation)
        {
            _builder = builder;
            _layerGenerator = new T();
            _builder.AddLayer(_layerGenerator, operation);
        }

        public TerrainGeneratorBuilder Builder()
        {
            return _builder;
        }
    }
}
