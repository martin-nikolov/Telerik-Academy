/*
    4. Write a script that finds the lexicographically smallest
    and largest property in document, window and navigator objects.
*/

taskName = "4. Property finder in document";

function Main(bufferElement) {
    getProperties([document, window, navigator]);
}

function getProperties(containers) {
    if (!Array.isArray(containers)) {
        return;
    }

    for (var object in containers) {
        var properties = [];

        for (var prop in containers[object]) {
            properties.push(prop);
        }

        properties.sort();

        WriteLine(containers[object]);
        WriteLine('Smallest: ' + properties.shift());
        WriteLine('Largest: ' + properties.pop());
        WriteLine();
    }
}