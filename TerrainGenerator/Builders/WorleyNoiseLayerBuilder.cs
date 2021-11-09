using System;

using TerrainGenerator.Enums;
using TerrainGenerator.Models;
using TerrainGenerator.Models.Implementations.TerrainLayerGenerators;

namespace TerrainGenerator.Builders
{
    public sealed class WorleyNoiseLayerBuilder : LayerGeneratorBaseBuilder<WorleyNoiseLayerGenerator>
    {
        public WorleyNoiseLayerBuilder(TerrainGeneratorBuilder builder, IOperation operation) : base(builder, operation)
        {
        }

        public WorleyNoiseLayerBuilder SetGridSize(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be more than 0");
            }

            _layerGenerator.GridSize = size;

            return this;
        }

        public WorleyNoiseLayerBuilder SetCellPointCount(int count, bool randomize)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be more than 0");
            }

            _layerGenerator.CellPointCount = count;
            _layerGenerator.RandomizeCellPointCount = randomize;

            return this;
        }

        public WorleyNoiseLayerBuilder SetRadius(float radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be more than 0");
            }

            _layerGenerator.Radius = radius;

            return this;
        }

        public WorleyNoiseLayerBuilder SetMetricType(WorleyNoiseMetricType metricType)
        {
            if (!Enum.IsDefined(typeof(WorleyNoiseMetricType), metricType))
            {
                throw new ArgumentException("Invalid metric value", nameof(metricType));
            }

            _layerGenerator.MetricType = metricType;

            return this;
        }

        public WorleyNoiseLayerBuilder SetResultType(WorleyNoiseResultType resultType)
        {
            if (!Enum.IsDefined(typeof(WorleyNoiseResultType), resultType))
            {
                throw new ArgumentException("Invalid result type", nameof(resultType));
            }

            _layerGenerator.ResultType = resultType;

            return this;
        }
    }
}
