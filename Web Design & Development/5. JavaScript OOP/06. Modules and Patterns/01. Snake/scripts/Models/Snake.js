define(function(require) {
    var GlobalConsts = require('./GlobalConsts.js');
    var GameBlock = require('./GameBlock.js');

    var Snake = (function() {
        var _dirs = {
            up: { X: 0, Y: -1 },
            down: { X: 0, Y: 1 },
            left: { X: -1, Y: 0 },
            right: { X: 1, Y: 0 }
        };

        // Constructor
        function Snake(posX, posY) {
            this._head = new GameBlock(posX, posY);
            this._snakeBody = new Array(GlobalConsts.SNAKE_SIZE - 1);
            this._currentDir = "right";

            for (var i = 1; i <= this._snakeBody.length; i++) {
                this._snakeBody[i - 1] = new GameBlock(posX - GlobalConsts.BLOCK_SIZE * i, posY);
            }

            this._snakeBody.unshift(this._head);
        }

        Snake.prototype.getHead = function() {
            return this._head;
        };

        Snake.prototype.getBody = function() {
            return this._snakeBody;
        };

        Snake.prototype.grow = function() {
            var tail = this._snakeBody[this._snakeBody.length - 1];
            var newTail = new GameBlock(tail.X - GlobalConsts.BLOCK_SIZE,
                                        tail.Y + GlobalConsts.BLOCK_SIZE);
            this._snakeBody.push(newTail);
        };

        Snake.prototype.changeDirection = function(dir) {
            if (!dir) {
                return;
            }
            else if ((this._currentDir == 'left' || this._currentDir == 'right') && (dir == 'left' || dir == 'right')) {
                return;
            }
            else if ((this._currentDir == 'up' || this._currentDir == 'down') && (dir == 'up' || dir == 'down')) {
                return;
            }

            this._currentDir = dir;
        };

        Snake.prototype.move = function() {
            var currentDir = _dirs[this._currentDir];
            var tail = this._snakeBody.pop();
            tail = new GameBlock(this._head.X + GlobalConsts.BLOCK_SIZE * currentDir.X,
                                 this._head.Y + GlobalConsts.BLOCK_SIZE * currentDir.Y);
            this._head = tail;
            this._snakeBody.unshift(tail);
        };

        return Snake;
    }());

    return Snake;
});