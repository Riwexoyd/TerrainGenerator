namespace TerrainGenerator.Models
{
    public interface ILayer
    {
        int Height { get; }

        int Width { get; }

        float this[int row, int column] { get; }
    }
}
