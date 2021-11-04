using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TerrainGenerator.Utils.Helpers
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetImplInTypeAssembly(Type type)
        {
            return Assembly.GetAssembly(type)
                .GetTypes()
                .Where(i => !i.IsAbstract &&
                    !i.IsInterface &&
                    i != type &&
                    !type.IsGenericType && type.IsAssignableFrom(i) ||
                    (i.BaseType.IsGenericType && i.BaseType.GetGenericTypeDefinition() == type)
                    )
                .ToList();
        }
    }
}
