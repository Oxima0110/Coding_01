
Console.Clear();

int[] array = { 0, 2, 4, 10, 20, 5, 6, 1, 2 };
int[] sortedArray =  CountingSortExtended(array);

Console.WriteLine(string.Join(", ", array));
Console.WriteLine(string.Join(", ", sortedArray));


int[] CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int[] sortedArray = new int[inputArray.Length];
    int[] counters = new int[max + 1];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i]]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            sortedArray[index] = i;
            index++;
        }
    }

    return sortedArray;
}
