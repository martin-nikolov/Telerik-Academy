/*
	4. Write a script that finds the lexicographically smallest
	and largest property in document, window and navigator objects.
*/

taskName = "4. Property finder in document";

function Main(bufferElement) {
    GetProperties([document, window, navigator]);
}

function GetProperties(containers) {
	if (!Array.isArray(containers)) {
		return;
	}

    for (var object in containers) {
		var properties = [];

		for (properties[properties.length] in containers[object]);

		properties.sort();

		WriteLine(containers[object]);
		WriteLine('Smallest: ' + properties.shift());
		WriteLine('Largest: ' + properties.pop());
		WriteLine();
	}
}