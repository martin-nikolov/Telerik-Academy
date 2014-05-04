/*
    5. Sorting an array means to arrange its elements in increasing
    order. Write a script to sort an array. Use the "selection sort"
    algorithm: Find the smallest element, move it at the first 
    position, find the smallest from the rest, move it at the second
    position, etc.
    - Hint: Use a second array
*/

taskName = "5. Selection sort";

function Main(bufferElement) {

    var inputCollection = getCollectionWithRandoms();
    var randomElement = GetRandomInt(-15, 15);

    var inputElements = ReadLine("Enter elements:", inputCollection.join(', '));

    SetSolveButton(function() {
        ConsoleClear();

        var collection = ParseIntCollection(inputElements.value, [',', ' ']);
        sortAndPrintResult(collection);
    });
}

function sortAndPrintResult(collection) {
    WriteLine("Collection: " + collection.join(", ") + "<br>");
    collection = selectionSort(collection);
    WriteLine("Sorted collection: " + collection.join(", "));
}

function selectionSort(collection) {
    if (!Array.isArray(collection)) {
        throw new Error("Error! There is some incorrect input value!");
    }

    var index, swap;

    for (var i = 0; i < collection.length - 1; i++) {
        index = i;

        for (var j = i + 1; j < collection.length; j++) {
            if (collection[j] < collection[index]) {
                index = j;
            }
        }

        swap = collection[i];
        collection[i] = collection[index];
        collection[index] = swap;
    }

    return collection;
}

function getCollectionWithRandoms() {
    var collection = [];
    var length = 5;

    for (var i = 0; i < length; i++) {
        collection.push(GetRandomInt(-9, 9));
    }

    return collection;
}