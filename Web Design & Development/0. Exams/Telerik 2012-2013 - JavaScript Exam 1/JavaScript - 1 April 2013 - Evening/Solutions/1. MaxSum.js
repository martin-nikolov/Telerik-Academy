var args = [
    '8',
    '1',
    '6',
    '-9',
    '4',
    '4',
    '-2',
    '10',
    '-1'];

//var args=[
//'6',
//'1',
//'3',
//'-5',
//'8',
//'7',
//'-6'];

//var args = [
//    '9',
//    '-9',
//    '-8',
//    '-8',
//    '-7',
//    '-6',
//    '-5',
//    '-1',
//    '-7',
//    '-6'];

console.log(Solve(args));

function Solve(args) {
    var N = parseInt(args.shift());

    var currentSum = 0;
    var maxSum = Number.NEGATIVE_INFINITY;

    var integers = args.map(function (a) {
        return parseInt(a, 10);
    });

    for (var i = 0; i < N; i++) {
        currentSum += integers[i];

        if (currentSum > maxSum) {
            maxSum = currentSum;
        }

        if (currentSum < 0) {
            currentSum = 0;
        }
    }

    return maxSum;
}