/*
 04. Write a script that finds the maximal increasing
 sequence in an array.
 Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
*/

function FindMaxIncreasingSequence(numbers)
{
    if (!Array.isArray(numbers)) {

        console.log("Error! There is some incorrect input value!");
        return;
    }

    if (numbers.length == 1) return numbers[0];

    var maxIncreasingSequence = [numbers[0]];
    var bestSequence = new Array();

    var currentElement = numbers[0];

    for (i = 1; i < numbers.length; i++)
    {
        if (numbers[i] > currentElement)
        {
            maxIncreasingSequence.push(numbers[i]);
            currentElement = numbers[i];
        }
        else
        {
            currentElement = numbers[i];
            maxIncreasingSequence = [currentElement];
        }

        if (maxIncreasingSequence.length >= bestSequence.length)
            bestSequence = maxIncreasingSequence;
    }

    if (bestSequence.length == 1 && bestSequence[0] == numbers[numbers.length - 1])
    {
        // Example: 6 5 4 3 2 1 -> return 6 instead any other element
        return numbers[0];
    }
    else
    {
        return bestSequence;
    }
}

function PrintBestSequence(elements)
{
    console.log("Best sequence: " + elements.join(", "));
    console.log();
}

(function Solve() {

    PrintBestSequence(FindMaxIncreasingSequence([2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9]));

    PrintBestSequence(FindMaxIncreasingSequence([8, 1, 3, 5, 7, 9, 8]));

    PrintBestSequence(FindMaxIncreasingSequence([1, 1, 2, 2, 2, 3, 4, 5]));

}).call(this);