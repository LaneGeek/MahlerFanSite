using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public static class ExtensionMethods
    {
        public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;
    }
}
