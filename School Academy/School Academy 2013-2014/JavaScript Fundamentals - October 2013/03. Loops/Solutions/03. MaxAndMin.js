/*
 03. Write a script that finds the max and min number from a sequence of numbers
*/

function GetMaxMin(numbers) {

    if (!Array.isArray(numbers)) {
        console.log("Error! There is some incorrect input value!\n");
        return;
    }

    console.log("Numbers: " + numbers.join(", "));

    var max = numbers[0];
    var min = numbers[0];

    for (i = 1; i < numbers.length; i++) {

        if (numbers[i] > max) {
            max = numbers[i];
        }

        if (numbers[i] < min) {
            min = numbers[i];
        }
    }

    console.log("Max: %d", max);
    console.log("Min: %d\n", min);
}

(function Solve () {
    
    GetMaxMin(new Array(-1, 5, -4, 3, 2));

    GetMaxMin(5); // Incorrect (must be array)

    GetMaxMin(new Array(1, -1, 2, -2, 3, -3));
    
}).call(this);