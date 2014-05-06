var args = [
    '7',
    '1',
    '2',
    '-3',
    '4',
    '4',
    '0',
    '1'];
//
//var args = [
//    '6',
//    '1',
//    '3',
//    '-5',
//    '8',
//    '7',
//    '-6'];

//var args = [
//    '9',
//    '1',
//    '8',
//    '8',
//    '7',
//    '6',
//    '5',
//    '7',
//    '7',
//    '6'];

console.log(Solve(args));

function Solve(args) {
    var N = parseInt(args.shift());
    var numberOfSubsequences = 0;

    var integers = args.map(function (a) {
        return parseInt(a, 10);
    });

    for (var i = 1; i < N; i++) {
        if (integers[i] < integers[i - 1]) {
            numberOfSubsequences++;
        }
    }

    return numberOfSubsequences + 1;
}