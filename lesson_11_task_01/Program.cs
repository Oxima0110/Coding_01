
Console.Clear();

const int THREADS_NUMBER = 4; // константой задаем количество потоков 4
const int N = 100000; // константа размер массива
object locker = new object(); //создаем обьект для синхронизации

//int[] array = { -10, -5, -9,  0, 2, 5, 1, 3, 1, 0, 1};
//int[] sortedArray = CountingSortExtended(array);
Random rand = new Random();
int[] resSerial = new int[N].Select(r => rand.Next(0, 5)).ToArray();
int[] resParallel = new int[N];
Array.Copy(resSerial, resParallel, N); // копируем созданный массив в другой

CountingSortExtended(resSerial);
PrepareParallelCountingSort(resParallel);
Console.WriteLine(EqualityMatrix(resSerial, resParallel));


void PrepareParallelCountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int[max + offset + 1];

    int eachThreadCalc = N / THREADS_NUMBER; //количество вычислений на каждый поток
    var threadsParall = new List<Thread>(); // список для хранения потоков

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc; // вычисление начальной позиции работы потока
        int endPos = (i + 1) * eachThreadCalc; // вычисление конечной позиции работы потока
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsParall.Add(new Thread(() => countingSortParallel(inputArray, counters, offset, startPos, endPos))); // указываем какую функцию будем выполнять в потоке
        threadsParall[i].Start(); //запуск потока
    }
    foreach (var thread in threadsParall) //ожидание окончания работы потока
    {
        thread.Join();
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}

void countingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (locker) //замок на одновременную запись
        {
            counters[inputArray[i] + offset]++;
        }
    }
}

void CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;

    int[] counters = new int[max + offset + 1];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}

bool EqualityMatrix(int[] fmatrix, int[] smatrix)
{
    bool res = true;

    for (int i = 0; i < N; i++)
    {
        res = res && (fmatrix[i] == smatrix[i]);
    }
    return res;
}