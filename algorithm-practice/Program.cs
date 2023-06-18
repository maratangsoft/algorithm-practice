using algorithm_practice.Sorting;

// Code reference 1: https://blog.naver.com/ndb796
// Code reference 2: https://github.com/aalhour/C-Sharp-Algorithms
class Program
{
    static void Main(string[] args)
    {
        SortingExample();
    }
        
    static void SortingExample()
    {
        int[] array = { 10, 3, 7, 12, 67, 2, 0, 45 };

        Console.Write("original array: ");
        WriteArray(array);

        long startTime = DateTime.Now.Millisecond;

        // 선택 정렬
        //array.SelectionSortAsc();
        // 버블 정렬
        //array.BubbleSortAsc();
        // 삽입 정렬
        //array.InsertionSortAsc();
        // 퀵 정렬
        //array.QuickSortAsc(0, array.Length - 1);
        // 힙 정렬
        array.HeapSortAsc();

        // 소요시간 측정용
        // 유의미하게 시간 차이를 내려면 원소가 몇만 개는 있어야 할듯
        Console.WriteLine();
        long endTime = DateTime.Now.Millisecond;
        Console.WriteLine("time spent: " + (endTime - startTime) + "ms");

        Console.Write("sorting result: ");
        WriteArray(array);
    }

    static void WriteArray(int[] array)
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
        Console.WriteLine();
    }
}