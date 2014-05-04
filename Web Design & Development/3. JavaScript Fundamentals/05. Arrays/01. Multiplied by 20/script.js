taskName = "1. Multiplied by 20";

function Main(bufferElement) {

    var numbers = new Array(20);

    for (var i = 0; i < numbers.length; i++) {
        numbers[i] = i * 5;
    }

    WriteLine(numbers.join(', '));
}