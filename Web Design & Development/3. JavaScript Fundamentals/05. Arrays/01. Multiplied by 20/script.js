/*
    1. Write a script that allocates array of 20 integers 
    and initializes each element by its index multiplied 
    by 5. Print the obtained array on the console.
*/

taskName = "1. Multiplied by 20";

function Main(bufferElement) {

    var numbers = new Array(20);

    for (var i = 0; i < numbers.length; i++) {
        numbers[i] = i * 5;
    }

    WriteLine(numbers.join(', '));
}