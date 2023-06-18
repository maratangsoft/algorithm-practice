

namespace algorithm_practice
{
    internal static class Utils
    {
        internal static void Swap(this int[] array, int firstIndex, int secondIndex)
        {
            if (array.Length < 2 || firstIndex == secondIndex)
            {
                return;
            }
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;

            WriteInConsole(array);
        }

        private static void WriteInConsole(int[] array)
        {
            Console.Write("[");
            foreach (int item in array)
            {
                Console.Write(item);
                if (item != array.Last())
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
