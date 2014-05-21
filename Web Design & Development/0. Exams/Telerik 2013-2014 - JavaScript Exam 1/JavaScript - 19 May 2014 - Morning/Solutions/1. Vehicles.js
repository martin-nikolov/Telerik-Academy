function Solve(args) {
    var sum = parseInt(args);
    var totalCombinations = 0;

    for (var i = 0; i <= sum; i++) {
        for (var j = 0; j <= sum; j++) {
            for (var k = 0; k <= sum; k++) {
                var currentSum = i * 4 + j * 10 + k * 3;

                if (currentSum > sum) {
                    break;
                }

                if (currentSum == sum) {
                    totalCombinations++;
                }
            }
        }
    }

    return totalCombinations;
}