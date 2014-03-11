## Linear Data Structures

1. Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. Keep the sequence in `List<int>`.
* Write a program that reads `N` integers from the console and reverses them using a stack. Use the `Stack<int>` class.
* Write a program that reads a sequence of integers (`List<int>`) ending with an empty line and sorts them in an increasing order.
* Write a method that finds the longest subsequence of equal numbers in given `List<int>` and returns the result as new `List<int>`. Write a program to test whether the method works correctly.
* Write a program that removes from given sequence all negative numbers.
* Write a program that removes from given sequence all numbers that occur odd number of times.

  Example: `{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}`
* Write a program that finds in given array of integers (all belonging to the range `[0..1000]`) how many times each of them occurs.
    
    Example: `array = {3, 4, 4, 2, 3, 3, 4, 3, 2}`
    * 2 -> 2 times
    * 3 -> 4 times
    * 4 -> 3 times
* \* The majorant of an array of size `N` is a value that occurs in it at least `N / 2 + 1` times. Write a program to find the majorant of given array (if exists).
    
    Example: `{2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3`
* We are given the following sequence:

    ```
    S1 = N;
    S2 = S1 + 1;
    S3 = 2*S1 + 1;
    S4 = S1 + 2;
    S5 = S2 + 1;
    S6 = 2*S2 + 1;
    S7 = S2 + 2;
    ...
    ```

    Using the `Queue<T>` class write a program to print its first 50 members for given `N`.

    Example: `N = 2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...`
* \* We are given numbers N and M and the following operations:
    * `N = N + 1`
    * `N = N + 2`
    * `N = N * 2`
    
    Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
    * Example: `N = 5, M = 16`
    * Sequence: 5 -> 7 -> 8 -> 16
* Implement the data structure linked list. Define a class `ListItem<T>` that has two fields: value (of type `T`) and `NextItem` (of type `ListItem<T>`). Define additionally a class `LinkedList<T>` with a single field `FirstElement`(of type `ListItem<T>`).
* Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).
* Implement the ADT queue as dynamic linked list. Use generics (`LinkedQueue<T>`) to allow storing different data types in the queue.
* \* We are given a labyrinth of size `N` x `N`. Some of its cells are empty `0` and some are full `x`. We can move from an empty cell to another empty cell if they share common wall. Given a starting position `*` calculate and fill in the array the minimal distance from this position to any other cell in the array. Use `u` for all unreachable cells. 

```
| Input                 |
| --------------------- |
| 0 | 0 | 0 | x | 0 | x |
| 0 | x | 0 | x | 0 | x |
| 0 | * | x | 0 | x | 0 |
| 0 | x | 0 | 0 | 0 | 0 |
| 0 | 0 | 0 | x | x | 0 |
| 0 | 0 | 0 | x | 0 | x |
```

```
| Output                 |
| ---------------------- |
| 3 | 4 | 5 | x | u | x  |
| 2 | x | 6 | x | u | x  |
| 1 | * | x | 8 | x | 10 |
| 2 | x | 6 | 7 | 8 | 9  |
| 3 | 4 | 5 | x | x | 10 |
| 4 | 5 | 6 | x | u | x  |
```