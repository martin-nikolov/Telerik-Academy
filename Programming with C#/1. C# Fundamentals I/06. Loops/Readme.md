## Loops

1. Write a program that prints all the numbers from 1 to `N`.
* Write a program that prints all the numbers from 1 to `N`, that are not divisible by 3 and 7 at the same time.
* Write a program that reads from the console a sequence of `N` integers and returns the minimal and maximal of them.
* Write a program that calculates **N!/K!** for given `N` and `K` (1 < K < N).
* Write a program that calculates **N!*K! / (N-K)!** for given `N` and `K` (1 < K < N).
* Write a program that, for a given two integers `N` and `X`, calculates the sum **S = 0!/X<sup>0</sup> + 1!/X<sup>1</sup> + 2!/X<sup>2</sup> + ... + N!/X<sup>N</sup>**
* Write a program that reads a number `N` and calculates the sum of the first N members of the sequence of Fibonacci: **0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, ...** Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.
* Write a program that calculates the **greatest common divisor** (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).
* In the combinatorial mathematics, the **Catalan numbers** are calculated by the following formula:

    ![Screenshot](https://github.com/flextry/Telerik-Academy/blob/master/Programming%20with%20C%23/1.%20C%23%20Fundamentals%20I/06.%20Loops/09.%20Catalan%20formula/example.png?raw=true)
* Write a program to calculate the Nth Catalan number by given `N`.
* Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for loops and switch-case.
* Write a program that reads from the console a positive integer `N` (N < 20) and outputs a matrix like the following:
<table>
    <tr>
        <th colspan="3">N=3</th>
    </tr>
    <tr>
        <td>1</td>
        <td>2</td>
        <td>3</td>
    </tr>
    <tr>
        <td>2</td>
        <td>3</td>
        <td>4</td>
    </tr>
    <tr>
        <td>3</td>
        <td>4</td>
        <td>5</td>
    </tr>
</table>
<table>
    <tr>
        <th colspan="4">N=4</th>
    </tr>
    <tr>
        <td>1</td>
        <td>2</td>
        <td>3</td>
        <td>4</td>
    </tr>
    <tr>
        <td>2</td>
        <td>3</td>
        <td>4</td>
        <td>5</td>
    </tr>
    <tr>
        <td>3</td>
        <td>4</td>
        <td>5</td>
        <td>6</td>
    </tr>
    <tr>
        <td>4</td>
        <td>5</td>
        <td>6</td>
        <td>7</td>
    </tr>
</table>
* \*Write a program that calculates for given `N` how many trailing zeros are present at the end of the number N!. Examples:
    * N = 10 -> N! = 3628800 -> 2
    * N = 25 -> N! = 15511210043330985984000000 -> 6

    Does your program work for N = 50 000? Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
* \*Write a program that reads a positive integer `N` (N < 20) from console and outputs in the console the numbers 1 ... N<sup>2</sup> numbers arranged as a spiral.
<table>
    <tr>
        <th colspan="4">N=4</th>
    </tr>
    <tr>
        <td>1</td>
        <td>2</td>
        <td>3</td>
        <td>4</td>
    </tr>
    <tr>
        <td>12</td>
        <td>13</td>
        <td>14</td>
        <td>5</td>
    </tr>
    <tr>
        <td>11</td>
        <td>16</td>
        <td>15</td>
        <td>6</td>
    </tr>
    <tr>
        <td>10</td>
        <td>9</td>
        <td>8</td>
        <td>7</td>
    </tr>
</table>
