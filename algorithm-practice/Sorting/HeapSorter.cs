

namespace algorithm_practice.Sorting
{
    public static class HeapSorter
    {
        // 힙 정렬
        // 데이터를 힙 구조로 조정한 후 이 구조를 이용해서 정렬
        // 힙 구조: 완전 이진 트리 + 부모 노드가 자식보다 크거나(최대 힙) 작음(최소 힙)
        // Time Complexity: O(N*log N) 를 보장 (노드 N개 * O(log N))
        public static void HeapSortAsc(this int[] array)
        {
            int lastNode = array.Length - 1;
            // 완전 이진 트리이므로 노드의 인덱스에 2를 나누면(나머지 버림) 부모 노드 인덱스가 나옴
            int lastParent = lastNode / 2;

            // 힙 생성
            for (int i = lastParent; i >= 0; i--)
            {
                array.MaxHeapifyTopDown(i, lastNode);
            }

            Console.WriteLine("Heapify ended");
            Console.WriteLine();

            // 오름차순 힙 정렬
            for (int i = lastNode; i >= 0; i--)
            {
                // 가장 큰 수가 root에 있으므로 마지막 노드와 위치 교대
                array.Swap(0, i);
                // 마지막 노드를 제외하고 나머지를 최대 힙 정렬
                array.MaxHeapifyTopDown(0, i - 1);
            }
        }

        // 부모-자식 간에 크기에 따라 위치 조정하는 것을 Heapify 라 함 
        private static void MaxHeapifyTopDown(this int[] array, int parent, int lastNode)
        {
            int leftChild = parent * 2 + 1;
            int rightChild = leftChild + 1;

            // 기본값으로 부모가 가장 크다고 가정
            int largest = parent;

            // 왼쪽 자식노드가 존재하고 largest 노드 값보다 크다면
            // largest 인덱스를 왼쪽 자식노드 것으로 변경
            if (leftChild <= lastNode && array[leftChild] > array[largest])
            {
                largest = leftChild;
            }
            // 오른쪽 자식노드가 존재하고 largest 노드 값보다 크다면
            // largest 인덱스를 오른쪽 자식노드 것으로 변경
            if (rightChild <= lastNode && array[rightChild] > array[largest])
            {
                largest = rightChild;
            }
            // 부모가 가장 크지 않다면 가장 큰 자식노드와 위치 교대
            if (largest != parent)
            {
                array.Swap(largest, parent);
                array.MaxHeapifyTopDown(largest, lastNode);
            }
        }
    }
}
