using System.Collections.Generic;
using System.Linq;

namespace Framework
{
    public static class ListCreator
    {
        public static IReadOnlyList<T> ListOf<T>(params T[] elements) =>
            elements.ToList();
    }
}