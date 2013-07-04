## Methods

1. Write a method that asks the user for his name and prints "Hello, <name>" (for example, "Hello, Peter!"). Write a program to test this method.
* Write a method `GetMax()` with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method `GetMax()`.
* Write a method that returns the last digit of given integer as an English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".
* Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.
* Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).
* Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
    * Use the method from the previous exercise.
* Write a method that reverses the digits of given decimal number. Example: 256 -> 652
* Write a method that adds two positive integer numbers represented as arrays of digits (each array element `arr[i]` contains a digit; the last digit is kept in `arr[0]`). Each of the numbers that will be added could have up to 10 000 digits.
* Write a method that returns the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.
* Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.
* Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example: x<sup>2</sup> + 5 = 1x<sup>2</sup> + 0x + 5 -> { 5, 0, 1 }
* Extend the program to support also subtraction and multiplication of polynomials.
* Write a program that can solve these tasks:
    * Reverses the digits of a number
    * Calculates the average of a sequence of integers
    * Solves a linear equation a * x + b = 0

    Create appropriate methods. Provide a simple text-based menu for the user to choose which task to solve. Validate the input data:
    * The decimal number should be non-negative
    * The sequence should not be empty
    * a should not be equal to 0
* Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.
* \* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).
