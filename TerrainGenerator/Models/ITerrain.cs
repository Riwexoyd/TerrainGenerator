namespace TerrainGenerator.Models
{
    public interface ITerrain : ILayer
    {
        float[,] GetHeightMap();
    }
}
