/*
 05. Write a function that counts how many times given
 number appears in given array. Write a test function
 to check if the function is working correctly.
*/

function FrequentOfNumberInArray(elements, number)
{
    if (!Array.isArray(elements)) {

        console.log("Error! There is some incorrect input value!");
        return;
    }

    var integer = parseInt(number);

    if (Number.isNaN(integer)) {
        return "Error! There is some incorrect input value!";
    }

    var count = 0;

    for (var i = 0; i < elements.length; i++) {

        if (elements[i] == number) {

            count++;
        }
    };

    console.log("Number: " + number + " occurs " + count + " times.")
}

(function Solve() {

    FrequentOfNumberInArray([2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9], 2);

    FrequentOfNumberInArray([8, 1, 3, 5, 7, 9, 8], 8);

    FrequentOfNumberInArray([1, 1, 2, 2, 2, 3, 4, 5], 5);

    FrequentOfNumberInArray([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3], 4);

}).call(this);