define(function(require) {
    var _context = null;

    // Constructor
    function GameBlockDrawer(canvasCtx) {
        _context = canvasCtx;
    }

    GameBlockDrawer.prototype.drawGameBlocks = function(gameBlocks) {
        for (var i = 0; i < gameBlocks.length; i++) {
            _context.beginPath();
            _context.fillStyle = gameBlocks[i].fillColor;
            _context.strokeStyle = gameBlocks[i].strokeColor;
            _context.fillRect(gameBlocks[i].X, gameBlocks[i].Y, gameBlocks[i].blockSize, gameBlocks[i].blockSize);
            _context.strokeRect(gameBlocks[i].X, gameBlocks[i].Y, gameBlocks[i].blockSize, gameBlocks[i].blockSize);
            _context.closePath();
        }
    };

    return GameBlockDrawer;
});