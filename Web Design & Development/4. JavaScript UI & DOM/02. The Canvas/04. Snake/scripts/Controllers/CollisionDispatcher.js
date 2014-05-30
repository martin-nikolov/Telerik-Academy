define(function(require) {
    var _context = null;
    var _gameElements = null;

    // Constructor
    function CollisionDispatcher(canvasCtx, gameElements) {
        _context = canvasCtx;
        _gameElements = gameElements;
    }

    function isOutOfGameField(snakeHead) {
        var hitVerticalWall = (snakeHead.X - snakeHead.blockSize < 0 ||
            snakeHead.X + snakeHead.blockSize >= _context.canvas.width);

        var hitHorizontalWall = (snakeHead.Y - snakeHead.blockSize < 0 ||
            snakeHead.Y + snakeHead.blockSize >= _context.canvas.height);

        if (hitVerticalWall || hitHorizontalWall) {
            return true;
        }
    }

    function isSnakeEatItself(snakeHead, snakeBody) {
        for (var i = 1; i < snakeBody.length; i++) {
            if (snakeHead.X === snakeBody[i].X && snakeHead.Y === snakeBody[i].Y) {
                return true;
            }
        }
    }

    CollisionDispatcher.prototype.invalidStepDispatch = function() {
        var snakeHead = _gameElements['snake'].getHead();
        var snakeBody = _gameElements['snake'].getBody();

        if (isOutOfGameField(snakeHead)) {
            return true;
        }

        if (isSnakeEatItself(snakeHead, snakeBody)) {
            return true;
        }
    };

    CollisionDispatcher.prototype.foodDispatchIndex = function() {
        var snakeHead = _gameElements['snake'].getHead();
        var food = _gameElements['food'];

        for (var i = 0; i < food.length; i++) {
            if (snakeHead.X === food[i].X && food[i].Y === snakeHead.Y) {
                return i;
            }
        }

        return -1;
    };

    return CollisionDispatcher;
});