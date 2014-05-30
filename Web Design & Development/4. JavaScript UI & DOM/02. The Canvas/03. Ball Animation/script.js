window.onload = function () {
    var canvas = document.getElementById("the-canvas");
    var canvasCtx = canvas.getContext("2d");

    var radius = 10;
    var startX = radius;
    var startY = radius + 10;
    var changeX = 1;
    var changeY = 1;
    var canvasWidth = canvas.clientWidth;
    var canvasHeight = canvas.clientHeight;
    var strokeColor = 'white';

    function moveCircle() {
        canvasCtx.clearRect(0, 0, canvasCtx.canvas.width, canvasCtx.canvas.height);
        drawCircle(canvasCtx, startX, startY, radius, 0, 360);
        canvasCtx.strokeStyle = strokeColor;
        canvasCtx.stroke();

        startX += changeX;
        startY += changeY;

        if (startX <= radius || startX >= canvasWidth - radius) {
            changeX *= -1;
        }

        if (startY <= radius || startY >= canvasHeight - radius) {
            changeY *= -1;
        }

        requestAnimationFrame(moveCircle, 10);
    }

    requestAnimationFrame(moveCircle);
};

function drawCircle(canvasCtx, x, y, radius, from, to) {
    canvasCtx.beginPath();
    canvasCtx.arc(x, y, radius, from, to);
}