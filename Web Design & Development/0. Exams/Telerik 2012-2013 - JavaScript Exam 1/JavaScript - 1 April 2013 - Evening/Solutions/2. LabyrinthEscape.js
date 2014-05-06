/**
 * @return {string}
 */
function Solve(args) {
    var sizes = args[0].split(" ").map(function(x) {
        return parseInt(x);
    });

    var startCoords = args[1].split(" ").map(function(x) {
        return parseInt(x);
    });

    // Sizes of matrix
    var rows = sizes[0],
        cols = sizes[1];

    var matrix = createMatrix(rows, cols, args);

    // Startup cell / coords
    var currentRow = startCoords[0],
        currentCol = startCoords[1];

    var currentCell = matrix[currentRow][currentCol];
    currentCell.visited = true;

    var resultValue = currentCell.value,
        visitedCells = 1;

    while (true) {
        var nextCoords = getNextCoords(currentRow, currentCol, currentCell.dir);

        currentRow = nextCoords[0];
        currentCol = nextCoords[1];

        if (!isCellPassable(currentRow, currentCol, rows, cols)) {
            return "out " + resultValue;
        }
        else if (matrix[currentRow][currentCol].visited === true) {
            return "lost " + visitedCells;
        }

        currentCell.visited = true;
        currentCell = matrix[currentRow][currentCol];

        resultValue += currentCell.value;
        visitedCells++;
    }

    function createMatrix(rows, cols, args) {
        var matrix = new Array(rows);
        var value = 1;

        for (var i = 0; i < rows; i++) {
            matrix[i] = new Array(cols);

            for (var j = 0; j < cols; j++) {
                matrix[i][j] = Cell(args[i + 2][j], value++);
            }
        }

        return matrix;
    }

    // CELL - CONSTRUCTOR
    function Cell(dir, value) {
        if (!(this instanceof Cell)) {
            return new Cell(dir, value);
        }

        this.dir = dir;
        this.value = value;
        this.visited = false;
    }

    /**
     * @return {*[]}
     */
    function getNextCoords(x, y, dir) {
        if (dir === 'l') {
            y--;
        } 
        else if (dir === 'r') {
            y++;
        } 
        else if (dir === 'u') {
            x--;
        } 
        else if (dir === 'd') {
            x++;
        }

        return [x, y];
    }

    /**
     * @return {boolean}
     */
    function isCellPassable(cellX, cellY, rows, cols) {
        return cellX >= 0 && cellX < rows &&
            cellY >= 0 && cellY < cols;
    }
}