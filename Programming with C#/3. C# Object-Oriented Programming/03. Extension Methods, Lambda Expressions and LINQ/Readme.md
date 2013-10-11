## Extension Methods, Delegates, Lambda, LINQ

1. Implement an extension method `Substring(int index, int length)` for the class `StringBuilder` that returns `new StringBuilder` and has the same functionality as `Substring` in the class `String`.
2. Implement a set of extension methods for `IEnumerable<T>` that implement the following group functions: sum, product, min, max, average.
3. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.
4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
5. Using the extension methods `OrderBy()` and `ThenBy()` with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.
6. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
7. Using delegates write a class `Timer` that has can execute certain method at each `t` seconds.
8. \* Read in MSDN about the keyword `event` in C# and [how to publish events](http://msdn.microsoft.com/en-us/library/w369ty8x.aspx). Re-implement the above using .NET events and following the best practices.