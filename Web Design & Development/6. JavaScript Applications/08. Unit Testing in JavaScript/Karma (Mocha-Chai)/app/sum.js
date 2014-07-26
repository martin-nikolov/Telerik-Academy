function sum(numbers) {
    var numbersSum, i, number, len;
    numbersSum = 0;
    for (i = 0, len = numbers.length; i < len; i++) {
        number = numbers[i];
        numbersSum += number;
    }
    return numbersSum;
}