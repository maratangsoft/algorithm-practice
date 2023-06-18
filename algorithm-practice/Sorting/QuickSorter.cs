

namespace algorithm_practice.Sorting
{
    // 퀵 정렬
    // 분할-정복 알고리즘의 일종
    // Time Complexity: O(N*logN) (average)
    //                  O(N^2)      (worst)
    public static class QuickSorter
    {
        public static void QuickSortAsc(this int[] array, int start, int end)
        {
            Console.WriteLine("Quick Sorting Ascending");
            Console.WriteLine();

            _quickSortAsc(array, start, end);
        }

        public static void _quickSortAsc(int[] array, int start, int end)
        {
            // 미정렬 원소가 하나 남아있으면 함수 끝
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int i = start + 1;
            int j = end;

            // 앞쪽에서 시작한 포인터가 뒷쪽에서 시작한 포인터 위치를 넘어가기 전까지
            while (i <= j)
            {
                // 앞쪽부터 시작해서 pivot보다 큰 값을 만나면 그 위치를 기억
                while (i <= end && array[i] <= array[pivot])
                {
                    i++;
                }
                // 뒷쪽부터 시작해서 pivot보다 작은 값을 만나면 그 위치를 기억
                while (j > start && array[j] >= array[pivot])
                {
                    j--;
                }

                // pivot보다 큰 값의 위치가 pivot보다 작은 값에 비해 뒷쪽이라면
                // (== 이 pivot을 기준으로 한 정렬이 전부 끝났다면)
                // pivot보다 작은 값과 pivot 값의 위치 교대
                if (i > j)
                {
                    array.Swap(pivot, j);
                }
                // pivot보다 큰 값의 위치가 pivot보다 작은 값에 비해 앞쪽이라면
                // pivot보다 큰 값과 pivot보다 작은 값의 위치를 교대
                else
                {
                    array.Swap(i, j);
                }
            }
            // 현재 j는 pivot이 새로 이동한 위치

            // pivot이 새로 이동한 위치 왼쪽 부분만 따로 정렬
            _quickSortAsc(array, start, j - 1);
            // pivot이 새로 이동한 위치 오른쪽 부분만 따로 정렬
            _quickSortAsc(array, j + 1, end);
        }
    }
}
