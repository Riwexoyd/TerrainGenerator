using System;
using System.Collections.Generic;

using TerrainGenerator.Enums;

namespace TerrainGenerator.Models.Implementations.TerrainLayerGenerators
{
    internal sealed class WorleyNoiseLayerGenerator : ITerrainLayerGenerator
    {
        delegate int GetPointCountFunc();
        delegate float GetDistanceFunc(Vector2 first, Vector2 second);
        delegate float GetResultFunc(float first, float second);

        GetPointCountFunc GetPointCount;
        GetDistanceFunc GetDistance;
        GetResultFunc GetResult;
        List<Vector2>[,] pointArray;

        public int Size { get; set; } = 1;  //  Размер сетки
        public int PointCount { get; set; } = 1;  //  Число точек в ячейке
        public float Radius { get; set; } = 1;  //  Радиус поиска ближайшей точки

        public ILayer GenerateLayer(int width, int height, Random random)
        {
            SetPointType(random);
            SetMetric();
            SetResultType();

            CreateRandomPointArray(random);

            var layer = new Layer(height, width);

            float cellSize = (float)Math.Max(layer.Width, layer.Height) / (float)Size;
            for (int y = 0; y < layer.Height; ++y)
                for (int x = 0; x < layer.Width; ++x)
                    layer[y, x] = Noise(x / cellSize, y / cellSize);

            return layer;
        }

        //  Метод установки числа точек
        public void SetPointType(Random random, bool rand = false)
        {
            if (rand)  //  если случайное, то будет возвращать случайное число точек
                GetPointCount = () => random.Next(PointCount + 1);
            else GetPointCount = () => PointCount;  //  иначе будет строго возвращать число точек
        }

        //  Установка метрики шума Уорли
        public void SetMetric(WorleyNoiseMetricType metricType = WorleyNoiseMetricType.Euclid)
        {
            if (metricType == WorleyNoiseMetricType.Euclid)
                GetDistance = Vector2.GetEuclidDistance;
            else if (metricType == WorleyNoiseMetricType.Manhattan)
                GetDistance = Vector2.GetManhattanDistance;
            else GetDistance = Vector2.GetMaximumDistance;
        }

        //  Создание и заполнение массива случайных точек
        private void CreateRandomPointArray(Random random)
        {
            pointArray = new List<Vector2>[Size, Size];
            for (int y = 0; y < Size; ++y)
                for (int x = 0; x < Size; ++x)
                {
                    pointArray[y, x] = new List<Vector2>(GetPointCount());
                    for (int g = 0; g < GetPointCount(); ++g)
                        pointArray[y, x].Add(GetRandomVector(random, x, y));
                }
        }

        //  Функция, создающая случайную точку в заданной клетке
        private Vector2 GetRandomVector(Random random, int x, int y)
        {
            return new Vector2(x + (float)random.NextDouble(), y + (float)random.NextDouble());
        }

        //  Функция шума Уорли
        private float Noise(float x, float y)
        {
            Vector2 pos = new Vector2(x, y);  //  точка, для которой ищется расстояние
            float min1 = Radius;  //  минимальное расстояние
            float min2 = Radius;  //  второе минимальное расстояние
            for (int i = (int)Math.Floor(x - Radius); i <= (int)Math.Floor(x + Radius); ++i)
                for (int j = (int)Math.Floor(y - Radius); j <= (int)Math.Floor(y + Radius); ++j)
                {  //  рассматриваются все соседние клетки
                    if (i < 0 || j < 0 || i >= Size || j >= Size) continue;  //  если выход за пределы сетки, то переходим к следующей
                    foreach (Vector2 g in pointArray[j, i])
                    {
                        float d = GetDistance(pos, g);  //  находим минимальное расстояние
                        if (d < min1)  //  Если меньше 1 расстояния, то запоминаем его
                        {
                            min2 = min1;
                            min1 = d;
                        }
                        else
                        if (d < min2)  //  Если меньше 2 расстояние, то запоминаем его
                            min2 = d;
                    }
                }
            return GetResult(min1, min2);
        }

        //  Установка типа возвращаемого результата
        public void SetResultType(WorleyNoiseResultType resultType = WorleyNoiseResultType.MinDist)
        {
            if (resultType == WorleyNoiseResultType.MinDist)
                GetResult = (x, y) => x;
            else if (resultType == WorleyNoiseResultType.MulDust)
                GetResult = (x, y) => x * y;
            else if (resultType == WorleyNoiseResultType.SumDist)
                GetResult = (x, y) => (x + y) * 0.5f;
            else if (resultType == WorleyNoiseResultType.SubDist)
                GetResult = (x, y) => y - x;
            else GetResult = (x, y) => y;
        }
    }
}
