
const int N = 1000; // размер матрицы
const int THREADS_NUMBERS = 10; //количество потоков
int[,] serialMulRes = new int[N, N]; //результат выполнения умножения матрицы
int[,] threadMulRes = new int[N, N]; //результат параллельного умножения матрицы


int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix);
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes));


int[,] MatrixGenerator(int rows, int colums) // метод заполнения массива
{
    Random _rand = new Random();
    int[,] res = new int[rows, colums];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

void SerialMatrixMul(int[,] a, int[,] b) // метод умножения матриц
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы");
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

void PrepareParallelMatrixMul(int[,] a, int[,] b) // метод подготовки к многопоточности
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы");
    int eachThreadCalc = N / THREADS_NUMBERS; // считаем сколько операций придется на 1 поток
    var threadsList = new List<Thread>(); // список где будут храниться потоки
    for (int i = 0; i < THREADS_NUMBERS; i++) // будем создовать потоки
    {
        int startPos = i * eachThreadCalc; // начало диапазона потока
        int endPos = (i + 1) * eachThreadCalc; // окончание потока
                                               // если последний поток
        if (i == THREADS_NUMBERS - 1) endPos = N;
        threadsList.Add(new Thread(() => ParallellMatrixMul(a, b, startPos, endPos))); // в каждый поток мы записываем 
        // функцию умножения матрицы для диапазона данного потока
        threadsList[i].Start(); // запуск потока
    }
for(int i =0; i < THREADS_NUMBERS; i++) // ожидание время окончания работы потока
{
    threadsList[i].Join();
}
}

void ParallellMatrixMul(int[,] a, int[,] b, int startPos, int endPos) // метод параллельного умножения матриц
{
    for (int i = startPos; i < endPos; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                threadMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

bool EqualityMatrix(int[,] fmatrix, int[,] smatrix) // сравнение матриц
{
    bool res = true;
    for (int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fmatrix.GetLength(1); j++)
        {
            res = res && (fmatrix[i,j] == smatrix[i,j]);
        }
    }
    return res;
}
