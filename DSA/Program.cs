using DSA;

var array = new int[] { 1, 7, 56, 100, 6, 8, 3, 6, 5, 29, 100, 23, 35, 4 };
var kthLargest = new KthLargest(array);
Console.WriteLine(kthLargest.Get(10));

HeapSort ob = new HeapSort();
ob.sort(array, 3);

Console.WriteLine("Sorted array is");
printArray(array);

void printArray(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n; ++i)
        Console.Write(arr[i] + " ");
    Console.Read();
}
var input = Console.ReadLine();

Console.WriteLine(string.Concat(StackExamples.GetPostFix(input??"")));
