function Solve(args) {
    var coords = args.shift().split(' ').map(function (a) {
        return parseInt(a);
    });

    var R = coords[0];
    var C = coords[1];

    var _visitCelledCells = [];
    var _matrix = [];

    _matrix = args.map(function (row) {
        return row.split(' ');
    });

    var _directions = {
        dr: [1, 1], ur: [-1, 1], ul: [-1, -1], dl: [1, -1]
    };

    function getValue(row, col) {
        return Math.pow(2, row) + col;
    }

    function isCellPassable(row, col) {
        return 0 <= row && row < R &&
            0 <= col && col < C;
    }

    function visitCell(row, col) {
        _matrix[row][col] = 'X';
    }

    function isCellVisited(row, col) {
        return _matrix[row][col] === 'X';
    }

    var sum = 0;
    var row = 0;
    var col = 0;
    var direction;

    while (true) {
        if (!isCellPassable(row, col)) {
            return "successed with " + sum;
        }

        if (isCellVisited(row, col)) {
            return "failed at (" + row + ", " + col + ")";
        }

        sum += getValue(row, col);

        direction = _directions[_matrix[row][col]];
        visitCell(row, col);

        row += direction[0];
        col += direction[1];
    }
}