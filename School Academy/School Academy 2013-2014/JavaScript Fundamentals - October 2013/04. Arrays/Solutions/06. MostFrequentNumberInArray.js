/*
 06. Write a program that finds the most frequent
 number in an array. 
 Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
*/

function FindMostFrequentNumber(elements)
{
    if (!Array.isArray(elements)) {

        console.log("Error! There is some incorrect input value!");
        return;
    }

    elements.sort();

    var currentLength = 1;
    var currentElement = elements[0];

    bestElement = 0; bestLength = 0;

    if (elements.length == 1)
    {
        bestElement = currentElement;
        bestLength = 1;
        return;
    }

    for (i = 1; i < elements.length; i++)
    {
        if (elements[i] === currentElement)
        {
            currentLength++;
        }
        else
        {
            currentElement = elements[i];
            currentLength = 1;
        }

        if (currentLength >= bestLength)
        {
            bestLength = currentLength;
            bestElement = currentElement;
        }
    }

    PrintBestSequence(bestElement, bestLength);
}

function PrintBestSequence(bestElement, bestLength)
{
    console.log("Most frequent element: " + bestElement + " - " + bestLength + " times");

    console.log();
}

(function Solve() {

    FindMostFrequentNumber([2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9]);

    FindMostFrequentNumber([8, 1, 3, 5, 7, 9, 8]);

    FindMostFrequentNumber([1, 1, 2, 2, 2, 3, 4, 5]);

    FindMostFrequentNumber([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);

}).call(this);