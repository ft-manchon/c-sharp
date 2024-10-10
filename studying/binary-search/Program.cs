namespace binary_search;

class Program
{
static int BinarySearch(int[] list, int wantedItem)
{
    int firstPos = 0;
    int lastPos = list.Length - 1;

    while (firstPos <= lastPos)
    {
        int middle = (firstPos + lastPos) / 2;
        int guess = list[middle];

        if (guess == wantedItem)
        {
            return middle;
        }

        if (guess < wantedItem)
        {
            firstPos = middle + 1;
        }
        else
        {
            lastPos = middle - 1;
        }
    }
    return -1;
}

    static void Main(string[] args)
    {
        int[] list = {10, 23, 31, 45, 47, 48, 48, 49, 57, 60, 61, 67};
        //int[] list = { 2, 7, 16, 33, 39, 45, 58, 61, 83, 98 };
        Console.WriteLine(BinarySearch(list, 45));
    }
}
