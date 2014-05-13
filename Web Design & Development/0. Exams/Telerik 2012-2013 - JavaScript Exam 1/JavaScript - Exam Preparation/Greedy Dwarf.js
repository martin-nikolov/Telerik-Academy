/*
    Task: Greedy Dwarf
    http://bgcoder.com/Contests/52/CSharp-Part-2-2012-2013-4-Feb-2013-Morning
*/

var args = [
    '1, 3, -6, 7, 4 ,1, 12',
    '3',
    '1, 2, -3',
    '1, 3, -2',
    '1, -1'
];

console.log(Solve(args));

function Solve(args) {
    String.prototype.parseIntCollection = function () {
        return this.split(',').map(function (a) {
            return +a;
        });
    };

    var valley = args[0].parseIntCollection();
    var numberOfPatterns = parseInt(args[1]);
    var pattern = [];
    var maxSum = Number.NEGATIVE_INFINITY;

    for (var i = 0; i < numberOfPatterns; i++) {
        var visitedCells = [];
        var currentSum = 0;
        var valleyIndex = 0;
        var patternIndex = 0;

        pattern = args[i + 2].parseIntCollection();

        // valleyIndex ϵ [0; valley.length) and valleyIndex is not visited yet
        while (valleyIndex >= 0 && valleyIndex < valley.length && visitedCells[valleyIndex] !== true) {
            currentSum += valley[valleyIndex];
            visitedCells[valleyIndex] = true;

            valleyIndex += pattern[patternIndex++];

            if (patternIndex >= pattern.length) {
                patternIndex = 0;
            }
        }

        if (currentSum > maxSum) {
            maxSum = currentSum;
        }
    }

    return maxSum;
}