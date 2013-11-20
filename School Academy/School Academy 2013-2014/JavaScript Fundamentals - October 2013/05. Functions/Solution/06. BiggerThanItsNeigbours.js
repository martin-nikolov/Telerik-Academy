/*
 06. Write a function that checks if the element at
 given position in given array of integers is bigger
 than its two neighbors (when such exist).
*/

function IsBiggerThanItsNeigbours(numbers, index) {

    // Note: If exist only one neighbour method compares numbers[index] to 
    // its neighbour and return result of their comparison [true/false]...

    if (!Array.isArray(numbers)) {

        console.log("Error! There is some incorrect input value!");
        return;
    }

    index = parseInt(index);

    if (Number.isNaN(index)) {

        return "Error! There is some incorrect input value!";
    }

    if (index < 0 || index >= numbers.length)
        return false;

    else if (index == numbers.length - 1 && numbers.length > 1)
    {
        return numbers[index - 1] < numbers[index];
    }
    else if (index == 0 && numbers.length > 1)
    {
        return numbers[index] > numbers[index + 1];
    }
    else
    {
        // Number is between other two numbers
        return numbers[index - 1] < numbers[index] && numbers[index] > numbers[index + 1];
    }
}

function PrintResult(boolValue) {
    console.log((boolValue? "bigger" : "smaller") + " than its neighbours")
}

(function Solve() {

    PrintResult(IsBiggerThanItsNeigbours([2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9], 3)); // smaller

    PrintResult(IsBiggerThanItsNeigbours([8, 1, 3, 5, 7, 9, 8], 5)); // bigger

    PrintResult(IsBiggerThanItsNeigbours([1, 1, 2, 2, 2, 3, 4, 5], 0)); // smaller

    PrintResult(IsBiggerThanItsNeigbours([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3], 12)); // smaller

}).call(this);