window.onload = function() {
    var canvas = document.getElementById("the-canvas");
    var canvasCtx = canvas.getContext("2d");

    drawHouse(canvasCtx);
};

function drawHouse(canvasCtx) {
    var cx = 100;
    var cy = 175;

    var windowWidth = 100;
    var windowHeight = 70;

    var sideWidth = 300;
    var sideHeight = 250;

    var doorWidth = 100;
    var doorHeight = 150;

    var houseColors = {
        fill: "975B5B",
        stroke: "000000"
    };

    drawRoof(canvasCtx, cx, cy, sideWidth, sideHeight, houseColors);
    drawBase(canvasCtx, cx, cy, sideWidth, sideHeight, houseColors);

    drawWindow(canvasCtx, cx + 30, cy + 20, windowWidth, windowHeight, houseColors);
    drawWindow(canvasCtx, cx + windowWidth + 70, cy + 20, windowWidth, windowHeight, houseColors);
    drawWindow(canvasCtx, cx + windowWidth + 70, cy + windowWidth + 20, windowWidth, windowHeight, houseColors);

    drawDoor(canvasCtx, 130, 350, doorWidth, doorHeight, houseColors);
}

function drawRoof(canvasCtx, x, y, sideWidth, sideHeight, colors) {
    canvasCtx.beginPath();
    canvasCtx.moveTo(x, y);
    canvasCtx.lineTo(x + sideWidth / 2, y - sideHeight + 100);
    canvasCtx.lineTo(x + sideWidth, y);
    applyStyles(canvasCtx, colors.fill, colors.stroke);

    canvasCtx.beginPath();
    canvasCtx.fillRect(sideWidth, y - 110, 27, 70);
    applyStyles(canvasCtx, colors.fill);

    canvasCtx.beginPath();
    canvasCtx.moveTo(sideWidth, y - 110);
    canvasCtx.lineTo(sideWidth, y - 30);
    applyStyles(canvasCtx, colors.fill);

    canvasCtx.beginPath();
    canvasCtx.moveTo(sideWidth + 27, y - 110);
    canvasCtx.lineTo(sideWidth + 27, y - 30);
    applyStyles(canvasCtx, colors.fill);

    var radius = 12;
    drawEllipse(canvasCtx, 224, 125, 10, 0, 360, 1.4, 0.5);
    applyStyles(canvasCtx, colors.fill);
}

function drawBase(canvasCtx, x, y, sideWidth, sideHeight, colors) {
    canvasCtx.beginPath();
    canvasCtx.moveTo(x, y);
    canvasCtx.lineTo(x + sideWidth, y);
    canvasCtx.lineTo(x + sideWidth, y + sideHeight);
    canvasCtx.lineTo(x, y + sideHeight);

    applyStyles(canvasCtx, colors.fill, colors.stroke);
}

function drawWindow(canvasCtx, x, y, width, height, colors) {
    canvasCtx.fillStyle = colors.stroke;
    canvasCtx.strokeStyle = colors.fill;

    canvasCtx.fillRect(x, y, width, height);

    canvasCtx.beginPath();
    canvasCtx.moveTo(x + width / 2, y);
    canvasCtx.lineTo(x + width / 2, y + height);
    canvasCtx.moveTo(x, y + height / 2);
    canvasCtx.lineTo(x + width, y + height / 2);
    canvasCtx.stroke();
}

function drawDoor(canvasCtx, x, y, width, height, colors) {
    canvasCtx.strokeStyle = colors.stroke;
    y += height / 2;

    canvasCtx.beginPath();
    canvasCtx.lineWidth = 2;
    canvasCtx.moveTo(x, y);
    canvasCtx.lineTo(x, y - height + 50);

    canvasCtx.moveTo(x + width, y);
    canvasCtx.lineTo(x + width, y - height + 50);
    canvasCtx.moveTo(x, y - height + 50);
    canvasCtx.bezierCurveTo(x, 430 - height, x + width, 430 - height, x + width, y - height + 50);
    canvasCtx.stroke();

    canvasCtx.moveTo(x + width / 2, y - height + 15);
    canvasCtx.lineTo(x + width / 2, y);
    canvasCtx.stroke();

    var radius = 5;
    drawCircle(canvasCtx, x + width / 2 - 10, y - height / 2 + 20, radius, 0, 360);
    canvasCtx.stroke();
    drawCircle(canvasCtx, x + width / 2 + 10, y - height / 2 + 20, radius, 0, 360);
    canvasCtx.stroke();
}

function drawBezierCurve(ctx, xoff, yoff) {
  ctx.beginPath();
  ctx.moveTo(160 + xoff, 500 + yoff);
  ctx.bezierCurveTo(160 + xoff, 515 + yoff, 157 + xoff, 302 + yoff, 157 + xoff, 270 + yoff);
  ctx.bezierCurveTo(157 + xoff, 179 + yoff, 347 + xoff, 176 + yoff, 350 + xoff, 259 + yoff);
  ctx.stroke();
}

function drawCircle(canvasCtx, x, y, radius, from, to) {
    canvasCtx.beginPath();
    canvasCtx.arc(x, y, radius, from, to);
}

function drawEllipse(canvasCtx, x, y, radius, from, to, scaleX, scaleY) {
    'use strict';
    canvasCtx.save();
    canvasCtx.scale(scaleX, scaleY);
    canvasCtx.beginPath();
    canvasCtx.arc(x, y, radius, from, to);
    canvasCtx.restore();
}

function applyStyles(canvasCtx, fillStyle, strokeStyle) {
    'use strict';
    canvasCtx.fillStyle = fillStyle;
    canvasCtx.strokeStyle = strokeStyle;
    canvasCtx.fill();
    canvasCtx.stroke();
}