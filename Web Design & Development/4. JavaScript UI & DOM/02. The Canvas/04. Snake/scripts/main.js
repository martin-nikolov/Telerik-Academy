define(function(require) {
    var CANVAS = document.getElementById("the-canvas");
    var CONTEXT = CANVAS.getContext("2d");
    var GameEngine = require('scripts/Controllers/GameEngine.js');

    var speedInMs = 170;

    var gameEngine = new GameEngine(CONTEXT);
    gameEngine.startGame(speedInMs);
});