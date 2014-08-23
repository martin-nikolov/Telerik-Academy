## Data Structures, Algorithms and Complexity

1. What is the expected running time of the following C# code? Explain why. Assume the array's size is n.

```c#
long Compute(int[] arr)
{
    long count = 0;

    for (int i = 0; i < arr.Length; i++)
    {
        int start = 0, end = arr.Length - 1;

        while (start < end)
        {
            if (arr[start] < arr[end])
            {
                start++;
                count++;
            }
            else
            {
                end--;
            }
        }
    }

    return count;
}
```
    
### Algorithm Complexity: 
* приблизително O(N * (N - 1))

### Explanation:
* За всяка итерация на for-цикъла (0 -> N - 1), while-цикъла ще се изпълни точно N - 1 пъти. 

### Executions of if-conditional statement:
* При възходящо сортиран масив броя влизания в if (arr[start] < arr[end]) ще е точно N * (N - 1) пъти, а в else конструкцията 0 пъти.
    * Пример за N = 100
    * общ брой изпълнения (итерации на 2-та цикъла) -> 90 пъти
    * влизания във if -> 90 пъти
    * влизания в else -> 0 пъти

* При низходящо сортиран масив броя влизания в if (arr[start] < arr[end]) ще е 0 пъти, а в else -> N * (N - 1) пъти.
    * Пример за N = 100
    * общ брой изпълнения (итерации на 2-та цикъла) -> 90 пъти
    * влизания във if -> 0 пъти
    * влизания в else -> 90 пъти

* При масив със случайно наредени елементи, влизането в която и да е условна конструкция ще е средно [N * (N - 1)] / 2 пъти.
    * Пример за N = 100
    * общ брой изпълнения (итерации на 2-та цикъла) -> 90 пъти
    * влизания във if -> ~50% от N
    * влизания в else -> ~50% от N
    
2. What is the expected running time of the following C# code? Assume the input matrix has size of `n` * `m`. Explain why.

    ```c#
    long CalcCount(int[,] matrix)
    {
        long count = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            if (matrix[row, 0] % 2 == 0)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
    ```

### Algorithm Complexity: 
* среден случай (случайни числа в 1-ва колона): приблизително O((N / 2) * M)
* най-бърз (нечетни числа в 1-ва колона): N изпълнения на външния цикъл, вътрешният не се изпълнява нито 1 път => сложността е O(N)
* най-бавнен (четни числа в 1-ва колона): N изпълнения на външния цикъл и M изпълнения на вътрешният => сложността е О(N * M)

### Explanation:
* При матрица с размери N x M, външният цикъл (итериращ по редовете) ще се изпълнява винати точно N пъти.
* Вътрешният цикъл (итериращ по колоните) се изпълнява N x M пъти само при условието if (matrix[row, 0] % 2 == 0) -> true.
* Изразът if (matrix[row, 0] % 2 == 0) е true средно в 50% от случаите, тъй като числата се делят на четни/нечетни, а шанса да е четно/нечетно при случаен избор е точно 50%.
* Т.е. в средният случай, вътрешният цикъл ще бъде достигнат (N / 2) пъти, или ще се изпълни (N / 2) * M пъти.
* В случай, че числата във всички редове на 1-ва колона са четни, то вътрешният цикъл ще бъде достигнат N пъти, или ще се изпълни N * M пъти..
* В случай, че числата във всички редове на 1-ва колона са нечетни, то вътрешният цикъл ще бъде достигнат точно 0 пъти и сложността ще е N.

* \* What is the expected running time of the following C# code? Explain why.

    ```c#
    long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;

        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            sum += matrix[row, col];
        }

        if (row + 1 < matrix.GetLength(1))
        {
            sum += this.CalcSum(matrix, row + 1);
        }

        return sum;
    }

    Console.WriteLine(CalcSum(matrix, 0));
    ```

    Assume the input matrix has size of `n` * `m`.
    
### Algorithm Complexity: 
* приблизително O(N * M) => със забележката -> O(N ^ 2), тъй като N = M

### Explanation:
* Разглежда се матрица с размери N * M.
* За всяко рекурсивно извикване, for-цикъла се изпълнява точно N пъти. Броят на рекурсивните извиквания е M пъти.

### Remarks:
* Функцията работи само при N = M, при правоъгълна матрица поведението на метода не е коректно. 
