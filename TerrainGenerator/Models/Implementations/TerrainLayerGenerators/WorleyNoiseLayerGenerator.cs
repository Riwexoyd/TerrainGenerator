using System;
using System.Collections.Generic;

using TerrainGenerator.Enums;
using TerrainGenerator.Helpers;

namespace TerrainGenerator.Models.Implementations.TerrainLayerGenerators
{
    internal sealed class WorleyNoiseLayerGenerator : ITerrainLayerGenerator
    {
        public int GridSize { get; set; } = 1;

        public int CellPointCount { get; set; } = 1;

        public float Radius { get; set; } = 1;

        public bool RandomCellPointCount { get; set; } = false;

        public WorleyNoiseMetricType MetricType { get; set; } = WorleyNoiseMetricType.Euclid;

        public WorleyNoiseResultType ResultType { get; set; } = WorleyNoiseResultType.MinDist;


        public ILayer GenerateLayer(int width, int height, Random random)
        {
            var distanceFunc = GetMetricFunc();
            var resultFunc = GetResultFunc();
            var pointArray = CreateRandomPointArray(random);

            var layer = new Layer(height, width);
            var cellSize = (float)Math.Max(layer.Width, layer.Height) / (float)GridSize;
            for (int y = 0; y < layer.Height; ++y)
            {
                for (int x = 0; x < layer.Width; ++x)
                {
                    layer[y, x] = Noise(pointArray, distanceFunc, resultFunc, x / cellSize, y / cellSize);
                }
            }

            return layer;
        }

        private Func<int> GetPointCountFunc(Random random)
        {
            if (RandomCellPointCount)
            {
                return () => random.Next(CellPointCount + 1);
            }
            else
            {
                return () => CellPointCount;
            }
        }

        private Func<Vector2, Vector2, float> GetMetricFunc()
        {
            switch (MetricType)
            {
                case WorleyNoiseMetricType.Euclid:
                    {
                        return MathHelper.GetEuclidDistance;
                    }
                case WorleyNoiseMetricType.Manhattan:
                    {
                        return MathHelper.GetManhattanDistance;
                    }
                case WorleyNoiseMetricType.Maximum:
                    {
                        return MathHelper.GetMaximumDistance;
                    }
                default:
                    {
                        return MathHelper.GetEuclidDistance;
                    }
            }
        }

        private List<Vector2>[,] CreateRandomPointArray(Random random)
        {
            var getPointCountFunc = GetPointCountFunc(random);
            var _pointArray = new List<Vector2>[GridSize, GridSize];
            for (int y = 0; y < GridSize; ++y)
            {
                for (int x = 0; x < GridSize; ++x)
                {
                    _pointArray[y, x] = new List<Vector2>(getPointCountFunc());
                    for (int g = 0; g < getPointCountFunc(); ++g)
                    {
                        _pointArray[y, x].Add(GetRandomVector(random, x, y));
                    }
                }
            }
            return _pointArray;
        }

        private Vector2 GetRandomVector(Random random, int x, int y)
        {
            return new Vector2(x + (float)random.NextDouble(), y + (float)random.NextDouble());
        }

        private float Noise(List<Vector2>[,] pointArray, Func<Vector2, Vector2, float> distanceFunc, Func<float, float, float> resultFunc, float x, float y)
        {
            Vector2 pos = new Vector2(x, y);
            float min1 = Radius;
            float min2 = Radius;
            for (int i = (int)Math.Floor(x - Radius); i <= (int)Math.Floor(x + Radius); ++i)
            {
                for (int j = (int)Math.Floor(y - Radius); j <= (int)Math.Floor(y + Radius); ++j)
                {
                    if (i < 0 || j < 0 || i >= GridSize || j >= GridSize)
                    {
                        continue;
                    }

                    foreach (Vector2 g in pointArray[j, i])
                    {
                        var d = distanceFunc(pos, g);
                        if (d < min1)
                        {
                            min2 = min1;
                            min1 = d;
                        }
                        else if (d < min2)
                        {
                            min2 = d;
                        }
                    }
                }
            }

            return resultFunc(min1, min2);
        }

        private Func<float, float, float> GetResultFunc()
        {
            switch (ResultType)
            {
                case WorleyNoiseResultType.MinDist:
                    {
                        return (x, y) => x;
                    }

                case WorleyNoiseResultType.MulDust:
                    {
                        return (x, y) => x * y;
                    }

                case WorleyNoiseResultType.SumDist:
                    {
                        return (x, y) => (x + y) * 0.5f;
                    }

                case WorleyNoiseResultType.SubDist:
                    {
                        return (x, y) => y - x;
                    }

                case WorleyNoiseResultType.SecMinDist:
                    {
                        return (x, y) => y;
                    }

                default:
                    {
                        return (x, y) => x;
                    }
            }
        }
    }
}
