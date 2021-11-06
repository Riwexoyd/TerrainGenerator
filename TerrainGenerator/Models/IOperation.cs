namespace TerrainGenerator.Models
{
    public interface IOperation
    {
        ILayer Execute(ILayer first, ILayer second);
    }
}
