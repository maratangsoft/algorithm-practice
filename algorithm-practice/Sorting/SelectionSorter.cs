

namespace algorithm_practice.Sorting
{
    // 선택 정렬
    // Time Complexity: O(N^2)
    public static class SelectionSorter
    {
        public static void SelectionSortAsc(this int[] array)
        {
            Console.WriteLine("Selection Sorting Ascending");
            Console.WriteLine();

            int i, j, min;
            int minIndex = 0;

            for (i = 0; i < array.Length; i++)
			{
                Console.WriteLine("\n=== i=" + i + " ===");

                // 매 루프마다 최솟값 초기화
                min = int.MaxValue;

                // 포인터가 위치한 원소부터 시작해서 배열에서 가장 작은 숫자 찾기
                for (j = i; j < array.Length; j++)
                {
                    if (min > array[j])
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }
                // 현재 포인터가 위치한 원소를 가장 작은 숫자로 대체
                array.Swap(i, minIndex);
            }
        }
    }
}