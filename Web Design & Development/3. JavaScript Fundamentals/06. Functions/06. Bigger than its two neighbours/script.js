/*
    6. Write a function that checks if the element at
    given position in given array of integers is bigger
    than its two neighbors (when such exist).
*/

taskName = "6. Bigger than its two neighbours";

function Main(bufferElement) {
    var inputCollection = getCollectionWithRandoms();
    var randomIndex = GetRandomInt(inputCollection.length - 1);

    var inputElements = ReadLine("Enter elements:", inputCollection.join(', '));
    var index = ReadLine("Enter a index: ", randomIndex);

    SetSolveButton(function () {
        ConsoleClear();

        var integers = ParseIntCollection(inputElements.value, [',', ' ']);
        var selectedIndex = index.value;
        var isBigger = isBiggerThanNeighbours(integers, selectedIndex);

        WriteLine(Format("Array[{0}] = {1}<br>", selectedIndex, integers[selectedIndex]));
        WriteLine("Bigger than its neighbors: " + (isBigger ? "TRUE" : "FALSE"));
    });
}

function isBiggerThanNeighbours(collection, index) {
    index = parseInt(index);

    if (!Array.isArray(collection) || (!index && index !== 0) ||
        index < 0 || index >= collection.length) {
        throw new Error("Error! There is some invalid input value!");
    }

    var target = collection[index];
    var previous = collection[index - 1], next = collection[index + 1];

    if ((previous && previous >= target) || (next && next >= target)) {
        return false;
    }

    return true;
}

function getCollectionWithRandoms() {
    var collection = [];
    var length = GetRandomInt(5, 10);

    for (var i = 0; i < length; i++) {
        collection.push(GetRandomInt(-15, 15));
    }

    return collection;
}