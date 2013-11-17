/*
 02. Write a script that compares two char 
 arrays lexicographically (letter by letter).
*/

// Compares two char arrays lexicographically (letter by letter).
function CompareTwoCharArrays(firstArray, secondArray) {
	
	if (!Array.isArray(firstArray) || !Array.isArray(secondArray)) {

		console.log("Error! There is some incorrect input value!\n");
        return;
	}

    var smallerSize = Math.min(firstArray.length, secondArray.length);

    var result = "[" + firstArray + "] <=> [" + secondArray +"] -> ";

    for (i = 0; i < smallerSize; i++) {

        if (firstArray[i] < secondArray[i]) {
            result += ("The first array is lexicographically before the second one.\n");
            console.log(result);
            return;
        }
        else if (firstArray[i] > secondArray[i]) {

            result += ("The second array is lexicographically before the first one.\n");
            console.log(result);
            return;
        }
        else if (i == smallerSize - 1 && firstArray.Length != secondArray.Length) {

            result += (
                "The {0} array is lexicographically before the {1} one.\n",
                firstArray.Length > secondArray.Length ? "second" : "first",
                firstArray.Length > secondArray.Length ? "first" : "second");
            console.log(result);
            return;
        }
    }

    // Out of for-loop => equal elements
    result += ("The arrays have equal elements!\n");
    console.log(result);
}

(function Solve() {

	CompareTwoCharArrays(new Array('a'), new Array('b'));

	CompareTwoCharArrays(new Array('b'), new Array('a'));

	CompareTwoCharArrays(new Array('a'), new Array('a'));

	CompareTwoCharArrays(new Array('a', 'c', 'b'), new Array('a', 'b', 'c'));

	CompareTwoCharArrays(new Array('a', 'b', 'b'), new Array('a', 'c', 'c'));

}).call(this);