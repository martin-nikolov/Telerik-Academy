define(function(require) {
    var GameEngine = require('scripts/Controllers/GameEngine.js');

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1024,
        height: 640
    });
    var layer = new Kinetic.Layer();

    var gameEngine = new GameEngine(stage, layer);
    gameEngine.startGame();
});