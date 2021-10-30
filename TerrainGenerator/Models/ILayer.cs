namespace TerrainGenerator.Models
{
    public interface ILayer
    {
        float this[int row, int column] { get; }
    }
}
