using UnityEngine;


namespace Lesson7
{
    public static class MyExtentions
    {
        public static int CountSymbols (this string self)
        {
            return self.Length;
        }
    }
}
