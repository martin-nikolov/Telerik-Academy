define(function(require) {
    var CollisionDispatcher = (function() {
        // Constructor
        function CollisionDispatcher(canvasCtx, gameElements) {
            this._context = canvasCtx;
            this._gameElements = gameElements;
        }

        CollisionDispatcher.prototype._isOutOfGameField = function(snakeHead) {
            var hitVerticalWall = (snakeHead.X - snakeHead.blockSize < 0 ||
                snakeHead.X + snakeHead.blockSize >= this._context.canvas.width);

            var hitHorizontalWall = (snakeHead.Y - snakeHead.blockSize < 0 ||
                snakeHead.Y + snakeHead.blockSize >= this._context.canvas.height);

            if (hitVerticalWall || hitHorizontalWall) {
                return true;
            }
        }

        CollisionDispatcher.prototype._isSnakeEatItself = function(snakeHead, snakeBody) {
            for (var i = 1; i < snakeBody.length; i++) {
                if (snakeHead.X === snakeBody[i].X && snakeHead.Y === snakeBody[i].Y) {
                    return true;
                }
            }
        }

        CollisionDispatcher.prototype.invalidStepDispatch = function() {
            var snakeHead = this._gameElements['snake'].getHead();
            var snakeBody = this._gameElements['snake'].getBody();

            if (this._isOutOfGameField(snakeHead)) {
                return true;
            }

            if (this._isSnakeEatItself(snakeHead, snakeBody)) {
                return true;
            }
        };

        CollisionDispatcher.prototype.foodDispatchIndex = function() {
            var snakeHead = this._gameElements['snake'].getHead();
            var food = this._gameElements['food'];

            for (var i = 0; i < food.length; i++) {
                if (snakeHead.X === food[i].X && food[i].Y === snakeHead.Y) {
                    return i;
                }
            }

            return -1;
        };

        return CollisionDispatcher;
    }());

    return CollisionDispatcher;
});