
using TerrainGenerator.Models;

namespace TerrainGenerator.BlazorWebApp.Models
{
    public class TerrainModel
    {
        private readonly ITerrain _terrain;

        public TerrainModel(ITerrain terrain)
        {
            _terrain = terrain;
        }

        public int Columns => _terrain.Width;

        public int Rows => _terrain.Height;


    }
}
