/*
	2. Write a function that removes all elements with a given value
	- Attach it to the array class
	- Read about prototype and how to attach methods
*/

taskName = "2. Remove Value from array";

function Main(bufferElement) {

    var inputArray = ReadLine("Enter elements: ", '[1, 2, 2, 3, 3, 3, 4, 4, 4, 4]');
    var removeElement = ReadLine("Remove element: ", '3');

    SetSolveButton(function() {
        ConsoleClear();

        var elements = SplitBySeparator(inputArray.value, [',', ' ', '\\[', ']']);
        var elementForRemoving = removeElement.value;

        WriteLine("New array: " + elements.remove(elementForRemoving).join(', '));
    });
}

Array.prototype.remove = function(element) {
    for (var i = this.length; i--;) {
        if (this[i] === element) {
            this.splice(i, 1);
        }
    }

    return this;
};