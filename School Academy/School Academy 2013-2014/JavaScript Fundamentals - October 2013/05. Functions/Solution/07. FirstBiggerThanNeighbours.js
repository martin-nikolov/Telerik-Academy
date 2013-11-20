/*
 06. Write a function that returns the index
 of the first element in array that is bigger
 than its neighbors, or -1, if there’s no such element.
 Use the function from the previous exercise.
*/

function IsBiggerThanItsNeighbours(numbers, index)
{
    if (index < 0 || index >= numbers.length) {

    	console.log("Invalid index!");
    	return;
    }

    if (index == numbers.length - 1 && numbers.length > 1)  {

        return numbers[index - 1] < numbers[index];
    }
    else if (index == 0 && numbers.length > 1) {

        return numbers[index] > numbers[index + 1];
    }
    else {

        // Number is between other two numbers
        return numbers[index - 1] < numbers[index] && numbers[index] > numbers[index + 1];
    }
}

function FindFirstBiggerThanNeighbours(numbers) {

    if (!Array.isArray(numbers)) {

        console.log("Error! There is some incorrect input value!");
        return;
    }

    for (var index = 0; index < numbers.length; index++) {

        if (IsBiggerThanItsNeighbours(numbers, index) === true)
            return index.toString();
    }

    return -1;
}

(function Solve() {

    console.log(FindFirstBiggerThanNeighbours([2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9]));

    console.log(FindFirstBiggerThanNeighbours([8, 1, 3, 5, 7, 9, 8]));

    console.log(FindFirstBiggerThanNeighbours([1, 1, 2, 2, 2, 3, 4, 5]));

    console.log(FindFirstBiggerThanNeighbours([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]));

}).call(this);