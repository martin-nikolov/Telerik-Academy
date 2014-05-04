/*
    3. Write a script that finds the maximal 
    sequence of equal collection in an array.
    Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
*/

taskName = "3. Max sequence of equals";

function Main(bufferElement) {

    var elements = ReadLine("Enter collection: ", '2, 1, 1, 2, 3, 3, 2, 2, 2, 1')

    SetSolveButton(function() {
        ConsoleClear();

        var collection = SplitBySeparator(elements.value, [',', ' ']);
        var bestSequence = findMaxSequenceOfEquals(collection);

        WriteLine("Max sequence of equals: " + bestSequence.join(', '));
    });
}

function findMaxSequenceOfEquals(collection) {
    if (!Array.isArray(collection)) {
        throw new Error("Error! There is some incorrect input value!");
    }

    var currentLength = 1;
    var currentElement = collection[0];
    var bestLength = 0;
    var bestElement; 

    if (collection.length === 1) {
        return [currentElement];
    }

    for (i = 1; i < collection.length; i++) {
        if (collection[i] === currentElement) {
            currentLength++;
        }
        else {
            currentElement = collection[i];
            currentLength = 1;
        }

        if (currentLength >= bestLength) {
            bestLength = currentLength;
            bestElement = currentElement;
        }
    }

    return Array.apply(null, new Array(bestLength)).map(function() {
        return bestElement; 
    });
}