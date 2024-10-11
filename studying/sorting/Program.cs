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

    static void MergeSort(int[] array, int start, int end)
    {
        int middle;

        if (start < end)
        {
            middle = (start + end) / 2;
            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);
            Merge(array, start, middle, end);
        }
    }
    static void Merge(int[] array, int start, int middle, int end)
    {
        int s1 = middle - start + 1;
        int s2 = end - middle;

        int[] leftArray = new int[s1];
        int[] rightArray = new int[s2];

        for (int i = 0; i < s1; i++)
        {
            leftArray[i] = array[start + i];
        }

        for (int j = 0; j < s2; j++)
        {
            rightArray[j] = array[middle + 1 + j];
        }

        int startIndex = 0, endIndex = 0;
        int mergedIndex = start;

        while (startIndex < s1 && endIndex < s2)
        {
            if (leftArray[startIndex] <= rightArray[endIndex])
            {
                array[mergedIndex] = leftArray[startIndex];
                startIndex++;
            }
            else
            {
                array[mergedIndex] = rightArray[endIndex];
                endIndex++;
            }
            mergedIndex++;
        }

        while (startIndex < s1)
        {
            array[mergedIndex] = leftArray[startIndex];
            startIndex++;
            mergedIndex++;
        }

        while (endIndex < s2)
        {
            array[mergedIndex] = rightArray[endIndex];
            endIndex++;
            mergedIndex++;
        }
    }

    static void QuickSort(int[] array, int start, int end)
    {
        if (start < end)
        {
            int pivot = Quick(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }
    }

    static int Quick(int[] array, int start, int end)
    {
        int left = start;
        int right = end;
        int pivot = array[start];

        while (left < right)
        {
            while (left <= end && array[left] <= pivot)
            {
                left++;
            }

            while (right >= 0 && array[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                int aux = array[left];
                array[left] = array[right];
                array[right] = aux;
            }
        }

        array[start] = array[right];
        array[right] = pivot;
        return right;
    }

    static void Main(string[] args)
    {
        int[] array = { 99, 82, 50, 67, 90, 20, 71, 8, 21, 18 };
        Console.WriteLine("Array original: " + string.Join(",", array));
        //BubbleSort(array);
        //SelectionSort(array);
        //InsertionSort(array); ;
        //MergeSort(array, 0, array.Length - 1);
        QuickSort(array, 0, array.Length - 1);
        Console.WriteLine("Array ordenado: " + string.Join(",", array));
    }
}
