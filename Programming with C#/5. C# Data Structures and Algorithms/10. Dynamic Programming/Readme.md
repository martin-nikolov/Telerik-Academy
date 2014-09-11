## Dynamic Programming

1. Write a program based on dynamic programming to solve the **Knapsack Problem**: you are given `N` products, each has weight `Wi` and costs `Ci` and a knapsack of capacity `M` and you want to put inside a subset of the products with highest cost and weight ≤ `M`. The numbers `N`, `M`, `Wi` and `Ci` are integers in the range `[1..500]`. Example: `M` = 10kg, `N` = 6, products:
    * `beer - weight = 3, cost = 2`
    * `vodka - weight = 8, cost = 12`
    * `cheese - weight = 4, cost = 5`
    * `nuts - weight = 1, cost = 4`
    * `ham - weight = 2, cost = 3`
    * `whiskey - weight = 8, cost = 13`
    
    Optimal solution: nuts + whiskey: `weight = 9`, `cost = 17`
* Write a program to calculate the **Minimum Edit Distance** between two words. `MED(x, y)` is the minimal sum of costs of edit operations used to transform x to y. Sample costs are given below:
    * `cost (replace a letter) = 1`
    * `cost (delete a letter) = 0.9`
    * `cost (insert a letter) = 0.8`

    Example: `x = "developer", y = "enveloped" -> cost = 2.7 `
    * `delete 'd':  "developer" -> "eveloper", cost = 0.9`
    * `insert 'n':  "eveloper" -> "enveloper", cost = 0.8`
    * `replace 'r' -> 'd':  "enveloper" -> "enveloped", cost = 1`
