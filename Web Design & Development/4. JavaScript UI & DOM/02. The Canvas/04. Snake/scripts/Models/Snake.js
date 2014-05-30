define(function(require) {

    var GlobalConsts = require('./GlobalConsts.js');
    var GameBlock = require('./GameBlock.js');

    var _dirs = {
        up: { X: 0, Y: -1 },
        down: { X: 0, Y: 1 },
        left: { X: -1, Y: 0 },
        right: { X: 1, Y: 0 }
    };

    var _currentDir = "right";
    var _snakeBody = null;
    var _head = null;

    // Constructor
    function Snake(posX, posY) {
        _head = new GameBlock(posX, posY);
        _snakeBody = new Array(GlobalConsts.SNAKE_SIZE - 1);

        for (var i = 1; i <= _snakeBody.length; i++) {
            _snakeBody[i - 1] = new GameBlock(posX - GlobalConsts.BLOCK_SIZE * i, posY);
        }

        _snakeBody.unshift(_head);
    }

    Snake.prototype.getHead = function() {
        return _head;
    };

    Snake.prototype.getBody = function() {
        return _snakeBody;
    };

    Snake.prototype.grow = function() {
        var tail = _snakeBody[_snakeBody.length - 1];
        var newTail = new GameBlock(tail.X - GlobalConsts.BLOCK_SIZE,
                                    tail.Y + GlobalConsts.BLOCK_SIZE);
        _snakeBody.push(newTail);
    };

    Snake.prototype.changeDirection = function(dir) {
        if (!dir) {
            return;
        }
        else if ((_currentDir == 'left' || _currentDir == 'right') && (dir == 'left' || dir == 'right')) {
            return;
        }
        else if ((_currentDir == 'up' || _currentDir == 'down') && (dir == 'up' || dir == 'down')) {
            return;
        }

        _currentDir = dir;
    };

    Snake.prototype.move = function() {
        var currentDir = _dirs[_currentDir];
        var tail = _snakeBody.pop();
        tail = new GameBlock(_head.X + GlobalConsts.BLOCK_SIZE * currentDir.X,
                             _head.Y + GlobalConsts.BLOCK_SIZE * currentDir.Y);
        _head = tail;
        _snakeBody.unshift(tail);
    };

    return Snake;
});