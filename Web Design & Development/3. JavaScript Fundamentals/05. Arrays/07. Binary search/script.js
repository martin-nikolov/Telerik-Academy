/*
    7. Write a program that finds the index of given element
    in a sorted array of integers by using the binary 
    search algorithm (find it in Wikipedia)
*/

taskName = "7. Binary Search";

function Main(bufferElement) {

    var inputCollection = getCollectionWithRandoms();
    var randomElement = GetRandomInt(-15, 15);

    var inputElements = ReadLine("Enter elements:", inputCollection.join(', '));
    var element = ReadLine("Searched element: ", randomElement);

    SetSolveButton(function() {
        ConsoleClear();

        var collection = ParseIntCollection(inputElements.value, [',', ' ']);
        collection.sort(function(a, b) { return a - b; });

        var targetIndex = collection.binarySearch(new Number(element.value));

        WriteLine("Collection: " + collection.join(', '));
        WriteLine(Format("<br>Element '{0}' found at index {1}.", element.value, targetIndex));
    });
}

 Array.prototype.binarySearch = function(find) {

    if (!IsNumber(find)) {
        return -1;
    }

    var low = 0, high = this.length - 1;
    var middle;

    while (low <= high) {

        middle = ((low + high) / 2) | 0;

        if (this[middle] < find) { low = middle + 1; continue; }
        if (this[middle] > find) { high = middle - 1; continue; }

        return middle;
    }

    return -1;
};

function getCollectionWithRandoms() {
    var collection = [];
    var length = GetRandomInt(5, 10);

    for (var i = 0; i < length; i++) {
        collection.push(GetRandomInt(-15, 15));
    }

    collection.sort(function(a, b) { return a - b; });

    return collection;
}