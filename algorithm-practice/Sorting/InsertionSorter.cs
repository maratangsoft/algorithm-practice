

namespace algorithm_practice.Sorting
{
    // 삽입 정렬
    // Time Complexity: O(N^2)
    // 필요한 경우에만 정렬을 하므로 데이터가 이미 거의 정렬돼 있을 경우 가장 빠름
    public static class InsertionSorter
    {
        public static void InsertionSortAsc(this int[] array)
        {
            Console.WriteLine("Insertion Sorting Ascending");
            Console.WriteLine();

            int i, j;

            for (i = 0; i < array.Length - 1; i++)
            {
                Console.WriteLine("\n=== i=" + i + " ===");

                j = i;
                while (j >= 0 && array[j] > array[j + 1])
                {
                    array.Swap(j, j + 1);
                    j--;
                }
            }
        }
    }
}
