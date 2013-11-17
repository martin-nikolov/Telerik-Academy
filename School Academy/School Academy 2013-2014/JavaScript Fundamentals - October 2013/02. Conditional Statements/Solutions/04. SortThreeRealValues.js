/*
* 4. Sort 3 real values in descending order using nested if statements.
*/

function SortDescendingThreeRealValues (first, second, third) {
    
    if (Number.isNaN(first) || Number.isNaN(second) || Number.isNaN(third)) {
        return "Error! There is some incorrect input value!";
    }

    if (first > second) {

        if (first > third) {

            swap = first;
            first = third;
            third = swap;
        }

        if (first > second) {

            swap = first;
            first = second;
            second = swap;
        }
    }
    else if (second > third) {

        if (first > third) {

            swap = first;
            first = third;
            third = swap;
        }

        if (second > third) { 

            swap = second;
            second = third;
            third = swap;
        }
    }

    return new Array(first, second, third);
}

function PrintNumbersOnConsole (numbers) {
    console.log(numbers[0] + " " + numbers[1] + " " + numbers[2]); 
}

(function Solve () {
    
    PrintNumbersOnConsole(SortDescendingThreeRealValues(1, 2, 3));

    PrintNumbersOnConsole(SortDescendingThreeRealValues(-1, -2, -3));

    PrintNumbersOnConsole(SortDescendingThreeRealValues(1.23, -2.23, 3.23));

    PrintNumbersOnConsole(SortDescendingThreeRealValues(-5.23, 2.23, -1));
    
}).call(this);