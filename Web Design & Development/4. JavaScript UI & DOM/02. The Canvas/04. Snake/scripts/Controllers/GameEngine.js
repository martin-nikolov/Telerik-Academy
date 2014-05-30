define(function(require) {

    var GlobalConsts = require('scripts/Models/GlobalConsts.js');
    var ScoreBoard = require('scripts/Models/ScoreBoard.js');

    var GameBlockDrawer = require('scripts/Controllers/GameBlockDrawer.js');
    var KeyboardEventHandler = require('scripts/Controllers/KeyboardEventHandler.js');
    var CollisionDispatcher = require('scripts/Controllers/CollisionDispatcher.js');
    
    var Snake = require('scripts/Models/Snake.js');
    var Food = require('scripts/Models/Food.js');

    var canvasCtx = null;
    var scoreBoard = null;
    var gameBlockDrawer = null;
    var keyboardEventHandler = null;
    var collisionDispatcher = null;
    var drawTimer = null;

    var gameElements = [];
    var snake = null;
    var food = [];

    // Constructor
    function GameEngine(canvasContext) {
        canvasCtx = canvasContext;
        scoreBoard = new ScoreBoard();
        gameBlockDrawer = new GameBlockDrawer(canvasCtx);
        keyboardEventHandler = new KeyboardEventHandler();
        collisionDispatcher = new CollisionDispatcher(canvasCtx, gameElements);

        addGameObjects();
        updateCanvasDrawing();
    }

    function addGameObjects() {
        snake = new Snake(GlobalConsts.BLOCK_SIZE * GlobalConsts.SNAKE_SIZE, canvasCtx.canvas.height / 2);

        for (var i = 0; i < GlobalConsts.FOOD_COUNT; i++) {
            food.push(generateFood());
        }

        gameElements['snake'] = snake;
        gameElements['food'] = food;
    }

    function updateCanvasDrawing() {
        clearGameField();

        var pressedKey = keyboardEventHandler.dispatch();
        snake.changeDirection(pressedKey);
        snake.move();

        gameBlockDrawer.drawGameBlocks(food);
        gameBlockDrawer.drawGameBlocks(snake.getBody());

        var foodDispatchIndex = collisionDispatcher.foodDispatchIndex();
        var invalidStepDispatch = collisionDispatcher.invalidStepDispatch();

        if (foodDispatchIndex !== -1) {
            snake.grow();
            food[foodDispatchIndex] = generateFood();
            scoreBoard.update(GlobalConsts.FOOD_PRICE);
        }
        else if (invalidStepDispatch === true) {
            endGame();
        }
    }

    function generateFood() {
        var foodX = 0;
        var foodY = 0;
        var spaceFromEdge = GlobalConsts.BLOCK_SIZE + 10;

        while (foodX < spaceFromEdge || foodX + spaceFromEdge > canvasCtx.canvas.width ||
                foodY < spaceFromEdge || foodY + spaceFromEdge > canvasCtx.canvas.height) {
            foodX = Math.round((Math.random() * canvasCtx.canvas.width - GlobalConsts.BLOCK_SIZE) / GlobalConsts.BLOCK_SIZE) * GlobalConsts.BLOCK_SIZE;
            foodY = Math.round((Math.random() * canvasCtx.canvas.height - GlobalConsts.BLOCK_SIZE) / GlobalConsts.BLOCK_SIZE) * GlobalConsts.BLOCK_SIZE;
        }

        return new Food(foodX, foodY);
    }

    function endGame() {
        clearInterval(drawTimer);

        var gameOverImage = document.getElementById('game-over');
        gameOverImage.style.display = 'block';

        scoreBoard.addPlayerToRank();
    }

    function clearGameField() {
        canvasCtx.clearRect(0, 0, canvasCtx.canvas.width, canvasCtx.canvas.height);
    }

    GameEngine.prototype.startGame = function(speedInMs) {
        drawTimer = setInterval(function() { updateCanvasDrawing(); }, speedInMs || GlobalConsts.SPEED_MS);
    };

    return GameEngine;
});