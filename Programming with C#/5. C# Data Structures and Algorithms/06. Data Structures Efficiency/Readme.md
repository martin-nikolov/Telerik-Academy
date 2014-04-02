## Data Structures Efficiency

1. A text file `students.txt` holds information about students and their courses in the following format:

    | First Name | Last Name | Course |
    | ---------- | --------- | ------ |
    | Kiril      | Ivanov    | C#     |
    | Stefka     | Nikolova  | SQL    |
    | Stela      | Mineva    | Java   |
    | Milena     | Petrova   | C#     |
    | Ivan       | Grigorov  | C#     |
    | Ivan       | Kolev     | SQL    |

    Using `SortedDictionary<K, T>` print the courses in alphabetical order and for each of them prints the students ordered by family and then by name:

    ```
        C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
        Java: Stela Mineva
        SQL: Ivan Kolev, Stefka Nikolova
    ```
* A large trade company has millions of articles, each described by barcode, vendor, title and price. Implement a data structure to store them that allows fast retrieval of all articles in given price range `[x...y]`. Hint: use `OrderedMultiDictionary<K, T>` from [Wintellect's Power Collections for .NET](http://powercollections.codeplex.com/).
* Implement a class `BiDictionary<K1, K2, T>` that allows adding triples `{ key1, key2, value }` and fast search by `key1`, `key2` or by both `key1` and `key2`.
    * Note: multiple values can be stored for given key.