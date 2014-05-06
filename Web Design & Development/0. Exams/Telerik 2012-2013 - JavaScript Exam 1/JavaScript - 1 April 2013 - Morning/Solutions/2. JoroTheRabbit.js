/**
 * @return {string}
 */
function Solve(args) {
    var firstLine = args[0].split(" ").map(function(x) {
        return parseInt(x);
    });

    var startCoords = args[1].split(" ").map(function(x) {
        return parseInt(x);
    });

    // Sizes of matrix
    var rows = firstLine[0],
        cols = firstLine[1];

    var matrix = createMatrix(rows, cols);

    var numberOfJumps = firstLine[2];
    var changes = [numberOfJumps];

    for (var i = 0; i < numberOfJumps; i++) {
        var coords = args[i + 2].split(" ").map(function(x) {
            return parseInt(x);
        });

        changes[i] = coords;
    }

    // Startup cell / coords
    var currentRow = startCoords[0],
        currentCol = startCoords[1];

    var currentCell = matrix[currentRow][currentCol];
    currentCell.visited = true;

    var resultValue = currentCell.value,
        visitedCells = 1;

    for (var i = 0; i < numberOfJumps; i++) {
        currentRow += changes[i][0];
        currentCol += changes[i][1];

        if (!isCellPassable(currentRow, currentCol, rows, cols)) {
            return "escaped " + resultValue;
        } 
        else if (matrix[currentRow][currentCol].visited === true) {
            return "caught " + visitedCells;
        }

        currentCell.visited = true;
        currentCell = matrix[currentRow][currentCol];

        resultValue += currentCell.value;
        visitedCells++;

        if (i + 1 == numberOfJumps) {
            i = -1;
        }
    }

    function createMatrix(rows, cols) {
        var matrix = new Array(rows);
        var value = 1;

        for (var i = 0; i < rows; i++) {
            matrix[i] = new Array(cols);

            for (var j = 0; j < cols; j++) {
                matrix[i][j] = Cell(value++);
            }
        }

        return matrix;
    }

    // CELL - CONSTRUCTOR
    function Cell(value) {
        if (!(this instanceof Cell)) {
            return new Cell(value);
        }

        this.value = value;
        this.visited = false;
    }

    /**
     * @return {boolean}
     */
    function isCellPassable(cellX, cellY, rows, cols) {
        return cellX >= 0 && cellX < rows &&
            cellY >= 0 && cellY < cols;
    }
}