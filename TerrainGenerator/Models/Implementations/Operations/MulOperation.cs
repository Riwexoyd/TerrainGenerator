using System;

namespace TerrainGenerator.Models.Implementations.Operations
{
    public sealed class MulOperation : PrimitiveOperation
    {
        protected override Func<float, float, float> Function => (x, y) => x * y;
    }
}
