/*
 03. Write a script that finds the maximal sequence
 of equal elements in an array.
 Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
*/

function FindBestSequence(elements)
{
    if (!Array.isArray(elements)) {

        console.log("Error! There is some incorrect input value!");
        return;
    }

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

    PrintBestSequence(elements, bestLength, bestElement);
}

function PrintBestSequence(elements, bestLength, bestElement)
{
    console.log("Array's elements: " + elements.join(", "));

    console.log("Best sequence: ");

    for (i = 0; i < bestLength; i++) console.log(bestElement + " ");

    console.log();
}

(function Solve() {

    FindBestSequence([4, 4, 4, 4, 3, 3, 3, 2, 2, 2, 1]);

    FindBestSequence([1, 3, 3, 3, 5, 5, 5, 5, 5, 2, 2]);

}).call(this);