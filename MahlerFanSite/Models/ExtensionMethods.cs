using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public static class ExtensionMethods
    {
        // These two methods will work any List because of the use of Generics
        public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;
        public static bool IsNotEmpty<T>(this List<T> list) => list.Count > 0;

        // This method will only work with a List of integers
        public static double Average(this List<int> list)
        {
            int sum = 0;
            foreach (int number in list)
            {
                sum += number;
            }
            return (double) sum / list.Count;
        }
    }
}
