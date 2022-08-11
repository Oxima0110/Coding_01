Console.Clear();
int[] array = { 0, 2, 3, 2, 1, 5, 9, 1, 1, 8 ,5 };

CountingSort(array);

Console.WriteLine(string.Join(", ", array));

void CountingSort(int[] inputArray)
{
    int[] counters = new int[10];

    for (int i = 0; i < inputArray.Length; i++) // проходим по всему первоначальному массиву
    {
        counters[inputArray[i]]++; //короткая запись нижних 2х строчек
        // int ourNumber = inputArray[i]; // увеличиваем в вспомогательном массиве элемент с индексом
        // counters[ourNumber]++; // равным цифре в первоначальном массиве на 1
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++) // проходим по вспомогательному массиву
    {
        for (int j = 0; j < counters[i]; j++) // это мы обходим повторения цифр которые мы посчитали
        {
            inputArray[index] = i; // значение индекса вспомогательного массива записывае столько раз сколько посчитали
            index++; // наприме 3 еденицы - записываем значение 1 три раза в первоначальный массив
        }
    }
}

