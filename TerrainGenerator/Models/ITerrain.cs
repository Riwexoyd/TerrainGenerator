namespace TerrainGenerator.Models
{
    public interface ITerrain : ILayer
    {
        int Height { get; }

        int Width { get; }
    }
}
