/*
    4. Write a script that finds the maximal increasing
    sequence in an array. 
    - Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
*/

taskName = "4. Max increasing sequence";

function Main(bufferElement) {

    var elements = ReadLine("Enter elements: ", '3, 2, 3, 4, 2, 2, 4');

    SetSolveButton(function () {
        ConsoleClear();

        var collection = ParseFloatCollection(elements.value, [',', ' ']);
        var bestSequence = findMaxIncreasingSequence(collection);

        WriteLine("Max increasing sequence: " + bestSequence.join(', '));
    });
}

function findMaxIncreasingSequence(collection) {
    if (!Array.isArray(collection)) {
        throw new Error("Error! There is some incorrect input value!");
    }

    if (collection.length === 1) {
        return [collection[0]];
    }

    var maxIncreasingSequence = [collection[0]];
    var bestSequence = [];

    var currentElement = collection[0];

    for (i = 1; i < collection.length; i++) {

        if (collection[i] > currentElement) {
            maxIncreasingSequence.push(collection[i]);
            currentElement = collection[i];
        }
        else {
            currentElement = collection[i];
            maxIncreasingSequence = [currentElement];
        }

        if (maxIncreasingSequence.length >= bestSequence.length) {
            bestSequence = maxIncreasingSequence;
        }
    }

    if (bestSequence.length == 1 && bestSequence[0] == collection[collection.length - 1]) {
        return [collection[0]]; // Example: 6 5 4 3 2 1 -> return 6 instead any other element
    }
    else {
        return bestSequence;
    }
}