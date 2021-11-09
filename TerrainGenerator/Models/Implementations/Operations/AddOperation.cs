using System;

namespace TerrainGenerator.Models.Implementations.Operations
{
    public sealed class AddOperation : PrimitiveOperation
    {
        protected override Func<float, float, float> Function => (x, y) => x + y;
    }
}
