using System;

namespace TerrainGenerator.Models.Implementations.Operations
{
    public sealed class DivOperation : PrimitiveOperation
    {
        protected override Func<float, float, float> Function => (x, y) => x / y;
    }
}
