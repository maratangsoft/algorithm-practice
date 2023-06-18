

namespace algorithm_practice.Sorting
{
    // 버블 정렬
    // Time Complexity: O(N^2)
    public static class BubbleSorter
    {

        public static void BubbleSortAsc(this int[] array)
        {
            Console.WriteLine("Bubble Sorting Ascending");
            Console.WriteLine();

            int i, j;

            for (i = 0; i < array.Length; i++)
            {
                Console.WriteLine("\n=== i=" + i + " ===");

                for (j = 0; j < array.Length - i - 1; j++)
                {
                    // 현재 포인터가 위치한 원소를 그 다음 원소를 비교해서
                    // 더 클 경우 위치 바꾸기
                    if (array[j] > array[j + 1])
                    {
                        array.Swap(j, j + 1);
                    }
                }
            }
        }
    }
}
