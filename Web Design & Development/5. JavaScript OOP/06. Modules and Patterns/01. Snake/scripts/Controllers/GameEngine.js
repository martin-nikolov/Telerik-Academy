define(function(require) {
    var GlobalConsts = require('scripts/Models/GlobalConsts.js');
    var ScoreBoard = require('scripts/Models/ScoreBoard.js');

    var GameBlockDrawer = require('scripts/Controllers/GameBlockDrawer.js');
    var KeyboardEventHandler = require('scripts/Controllers/KeyboardEventHandler.js');
    var CollisionDispatcher = require('scripts/Controllers/CollisionDispatcher.js');
    
    var Snake = require('scripts/Models/Snake.js');
    var Food = require('scripts/Models/Food.js');

    var GameEngine = (function() {
        var _canvasCtx = null;
        var _scoreBoard = null;
        var _gameBlockDrawer = null;
        var _keyboardEventHandler = null;
        var _collisionDispatcher = null;
        var _drawTimer = null;

        var _gameElements = [];
        var snake = null;
        var food = [];

        // Constructor
        function GameEngine(canvasContext) {
            _canvasCtx = canvasContext;
            _scoreBoard = new ScoreBoard(GlobalConsts.SCORE_CONTAINER_ID, GlobalConsts.TOP10_CONTAINER_ID);
            _gameBlockDrawer = new GameBlockDrawer(_canvasCtx);
            _keyboardEventHandler = new KeyboardEventHandler();
            _collisionDispatcher = new CollisionDispatcher(_canvasCtx, _gameElements);

            _addGameObjects();
            _updateCanvasDrawing();
        }

        function _addGameObjects() {
            snake = new Snake(GlobalConsts.BLOCK_SIZE * GlobalConsts.SNAKE_SIZE, _canvasCtx.canvas.height / 2);

            for (var i = 0; i < GlobalConsts.FOOD_COUNT; i++) {
                food.push(_generateFood());
            }

            _gameElements['snake'] = snake;
            _gameElements['food'] = food;
        }

        function _updateCanvasDrawing() {
            _clearGameField();

            var pressedKey = _keyboardEventHandler.dispatch();
            snake.changeDirection(pressedKey);
            snake.move();

            _gameBlockDrawer.drawGameBlocks(food);
            _gameBlockDrawer.drawGameBlocks(snake.getBody());

            var foodDispatchIndex = _collisionDispatcher.foodDispatchIndex();
            var invalidStepDispatch = _collisionDispatcher.invalidStepDispatch();

            if (foodDispatchIndex !== -1) {
                snake.grow();
                food[foodDispatchIndex] = _generateFood();
                _scoreBoard.update(GlobalConsts.FOOD_PRICE);
            }
            else if (invalidStepDispatch === true) {
                _endGame();
            }
        }

        function _generateFood() {
            var foodX = 0;
            var foodY = 0;
            var spaceFromEdge = GlobalConsts.BLOCK_SIZE + 10;

            while (foodX < spaceFromEdge || foodX + spaceFromEdge > _canvasCtx.canvas.width ||
                    foodY < spaceFromEdge || foodY + spaceFromEdge > _canvasCtx.canvas.height) {
                foodX = Math.round((Math.random() * _canvasCtx.canvas.width - GlobalConsts.BLOCK_SIZE) / GlobalConsts.BLOCK_SIZE) * GlobalConsts.BLOCK_SIZE;
                foodY = Math.round((Math.random() * _canvasCtx.canvas.height - GlobalConsts.BLOCK_SIZE) / GlobalConsts.BLOCK_SIZE) * GlobalConsts.BLOCK_SIZE;
            }

            return new Food(foodX, foodY);
        }

        function _clearGameField() {
            _canvasCtx.clearRect(0, 0, _canvasCtx.canvas.width, _canvasCtx.canvas.height);
        }

        function _endGame() {
            clearInterval(_drawTimer);

            var gameOverImage = document.getElementById('game-over');
            gameOverImage.style.display = 'block';

            _scoreBoard.addPlayerToRank();
        }

        GameEngine.prototype.endGame = function() {
            _endGame();
        }

        GameEngine.prototype.startGame = function(speedInMs) {
            _drawTimer = setInterval(function() { _updateCanvasDrawing(); }, speedInMs || GlobalConsts.SPEED_MS);
        };

        return GameEngine;
    }());

    return GameEngine;
});