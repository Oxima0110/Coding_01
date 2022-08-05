
int[] arr = { 0, -5, 2, 3, 5, 9, -1, 7 };
// int[] res = QuickSort(arr, 0, arr.Length - 1);
QuickSort(arr, 0, arr.Length -1);
Console.Write($"Отсортированный массив: [{string.Join(", ", arr)}]");

void QuickSort(int[] inputArray, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex) return;
    int pivot = GetPivotIndex(inputArray, minIndex, maxIndex);
    QuickSort(inputArray, minIndex, pivot - 1);
    QuickSort(inputArray, pivot + 1, maxIndex);
    return;
}

int GetPivotIndex(int[] inputArray, int minIndex, int maxIndex)
{
    int pivotIndex = maxIndex + 1;
    for (int i = maxIndex; i > minIndex; i--)
    {
        if (inputArray[i] > inputArray[minIndex])
        {
            pivotIndex--;
            Swap(inputArray, i, pivotIndex);
        }
    }
    pivotIndex--;
    Swap(inputArray, minIndex, pivotIndex);
    return pivotIndex;
}

void Swap(int[] inputArray, int leftValue, int rightValue)
{
    int temp = inputArray[rightValue];
    inputArray[rightValue] = inputArray[leftValue];
    inputArray[leftValue] = temp;
}


