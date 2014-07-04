define(function(require) {
    var GameBlockDrawer = (function() {
        // Constructor
        function GameBlockDrawer(canvasCtx) {
            this._context = canvasCtx;
        }

        GameBlockDrawer.prototype.drawGameBlocks = function(gameBlocks) {
            for (var i = 0; i < gameBlocks.length; i++) {
                this._context.beginPath();
                this._context.fillStyle = gameBlocks[i].fillColor;
                this._context.strokeStyle = gameBlocks[i].strokeColor;
                this._context.fillRect(gameBlocks[i].X, gameBlocks[i].Y, gameBlocks[i].blockSize, gameBlocks[i].blockSize);
                this._context.strokeRect(gameBlocks[i].X, gameBlocks[i].Y, gameBlocks[i].blockSize, gameBlocks[i].blockSize);
                this._context.closePath();
            }
        };

        return GameBlockDrawer;
    }());

    return GameBlockDrawer;
});