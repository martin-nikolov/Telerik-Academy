/*
    Task: Binary Digits Count
    http://bgcoder.com/Contests/1/CSharp-Fundamentals-2011-2012-Part-1-Sample-Exam
*/

var args = [
    '1',
    '10',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '10'
];

var args2 = [
    '0',
    '4',
    '20',
    '1337',
    '2147483648',
    '4000000000'
];

var args3 = [
    '0',
    '6',
    '1',
    '4',
    '16',
    '64',
    '256',
    '1024'
];

console.log(Solve(args));

function Solve(args) {
    var binaryDigit = args.shift();
    args.shift(); // length
    var _binaryDigitsCount = [];

    String.prototype.count = function (element) {
        var count = 0;

        for (var i = 0; i < this.length; i++) {
            if (this[i] === element) {
                count++;
            }
        }

        return count;
    };

    for (var number in args) {
        _binaryDigitsCount.push(parseInt(args[number]).toString(2).count(binaryDigit));
    }

    return _binaryDigitsCount.join('\n');
}