/*
 05. Sorting an array means to arrange its elements
 in increasing order. Write a script to sort an array.
 Use the "selection sort" algorithm: Find the smallest 
 element, move it at the first position, find the
 smallest from the rest, move it at the second position, etc.
*/

function Sort(numbers)
{
    if (!Array.isArray(numbers)) {

        console.log("Error! There is some incorrect input value!");
        return;
    }

    var index, swap;

    for (i = 0; i < numbers.length - 1; i++)
    {
        index = i;

        for (j = i + 1; j < numbers.length; j++)
            if (numbers[j] < numbers[index])
                index = j;

        swap = numbers[i];
        numbers[i] = numbers[index];
        numbers[index] = swap;
    }

    return numbers;
}

function PrintSortedNumbers(elements)
{
    console.log("Sorted numbers: " + elements.join(", "));
    console.log();
}

(function Solve() {

    PrintSortedNumbers(Sort([2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9]));

    PrintSortedNumbers(Sort([8, 1, 3, 5, 7, 9, 8]));

    PrintSortedNumbers(Sort([1, 1, 2, 2, 2, 3, 4, 5]));

}).call(this);