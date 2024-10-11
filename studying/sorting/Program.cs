namespace sorting;

class Program
{
    static void BubbleSort(int[] array)
    {
        bool swap = true;
        int last = array.Length - 1;
        int last_temp = array.Length - 1;

        while (swap)
        {
            int pos = 0;
            swap = false;
            int temp = 0;

            while (pos < last)
            {
                if (array[pos] > array[pos + 1])
                {
                    temp = array[pos];
                    array[pos] = array[pos + 1];
                    array[pos + 1] = temp;
                    swap = true;
                    last_temp = pos;
                }
                pos++;
            }
            last = last_temp;
        }
    }

    static void SelectionSort(int[] array)
    {
        int min, temp;

        for (int i = 0; i < array.Length - 1; i++)
        {
            min = i;

            for (int pos = i + 1; pos < array.Length; pos++)
            {
                if (array[pos] < array[min])
                {
                    min = pos;
                }
            }

            if (array[i] != array[min])
            {
                temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }
    }

    static void InsertionSort(int[] array)
    {
        int num, verifiedPos;

        for (int pos = 1; pos < array.Length; pos++)
        {
            num = array[pos];
            verifiedPos = pos - 1;

            while (verifiedPos >= 0 && num < array[verifiedPos])
            {
                array[verifiedPos + 1] = array[verifiedPos];
                verifiedPos--;
            }
            array[verifiedPos + 1] = num;
        }
    }

    static void MergeSort(int[] array)
    {

    }

    static void QuickSort(int[] array)
    {

    }

    static void Main(string[] args)
    {
        int[] array = { 99, 82, 50, 67, 90, 20, 71, 8, 21, 18 };
        Console.WriteLine("Array original: " + string.Join(",", array));
        //BubbleSort(array);
        //SelectionSort(array);
        InsertionSort(array);;
        //MergeSort(array);
        //QuickSort(array);
        Console.WriteLine("Array ordenado: " + string.Join(",", array));
    }
}
