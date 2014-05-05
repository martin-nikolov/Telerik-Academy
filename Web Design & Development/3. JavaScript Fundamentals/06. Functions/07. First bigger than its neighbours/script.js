/*
    7. Write a Function that returns the index of the first
    element in array that is bigger than its neighbors,
    or -1, if there’s no such element.
    Use the function from the previous exercise.
*/

taskName = "7. First bigger than its neighbours";

function Main(bufferElement) {
    var inputElements = ReadLine("Enter elements:", getCollectionWithRandoms().join(', '));

    SetSolveButton(function () {
        ConsoleClear();

        var elements = ParseIntCollection(inputElements.value, [',', ' ']);
        getFirstBiggerThanNeighbours(elements);
    });
}

function getFirstBiggerThanNeighbours(collection) {
    WriteLine("First bigger than its neighbours: <br>");
    for (var i = 0; i < collection.length; i++) {
        if (isBiggerThanNeighbours(collection, i)) {
            WriteLine(Format("Array[{0}] = {1}<br>", i, collection[i]));
            return;
        }
    }

    WriteLine("- There is no element bigger than its neighbours");
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
        collection.push(GetRandomInt(15));
    }

    return collection;
}