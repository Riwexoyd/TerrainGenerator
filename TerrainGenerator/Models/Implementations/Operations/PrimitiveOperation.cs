using System;

namespace TerrainGenerator.Models.Implementations.Operations
{
    public abstract class PrimitiveOperation : IOperation
    {
        protected abstract Func<float, float, float> Function { get; }

        public ILayer Execute(ILayer first, ILayer second)
        {
            return new CombineLayer(first, second, Function);
        }
    }
}
