/*
    Task: Triple Rotation of Digits
    http://bgcoder.com/Contests/Practice/Index/43#0
*/

var args = [
    '51234'
];

var args2 = [
    '180001'
];

var args3 = [
    '443'
];

var args4 = [
    '53'
];

console.log(Solve(args));

function Solve(args) {
    var numberAsArray = args[0].split('');

    for (var i = 0; i < 3; i++) {
        var lastDigit = numberAsArray.pop();
        numberAsArray.unshift(lastDigit);

        var validIntegerAsString = parseInt(numberAsArray.join('')).toString();
        numberAsArray = validIntegerAsString.split('');
    }

    return numberAsArray.join('');
}