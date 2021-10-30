namespace TerrainGenerator.Models
{
    public interface ITerrain : IGroupLayer
    {
        int Rows { get; }

        int Columns { get; }
    }
}
