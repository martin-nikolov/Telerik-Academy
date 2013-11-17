/*
 07. Write a program that finds the greatest of given 5 variables.
*/

function GetMax (numbers) {

    if (!Array.isArray(numbers)) {
        console.log("Error! There is some incorrect input value!\n");
        return;
    }

    console.log("Numbers: " + numbers.join(", "));

    var max = numbers[0];

    for (i = 1; i < numbers.length; i++) {

        if (numbers[i] > max) {
            max = numbers[i];
        }
    }

    console.log("Greatest number: %d\n", max);
}

(function Solve () {
    
    GetMax(new Array(-1, 5, -4, 3, 2));

    GetMax(5); // Incorrect

    GetMax(new Array(1, -1, 2, -2, 3, -3));
    
}).call(this);