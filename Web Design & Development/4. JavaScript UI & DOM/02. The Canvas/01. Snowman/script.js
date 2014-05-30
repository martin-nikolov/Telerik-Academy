window.onload = function () {
    var canvas = document.getElementById("the-canvas");
    var canvasCtx = canvas.getContext("2d");

    drawSnowMan(canvasCtx);
};

function drawSnowMan(canvasCtx) {
    var cx = 160;
    var cy = 220;

    var circleColors = {
        fill: "90CAD7",
        stroke: "327D8F"
    };

    var hatColors = {
        fill: "396693",
        stroke: "252422"
    };

    var faceStrokeColor = "20525D";

    drawHead(canvasCtx, cx, cy, circleColors, faceStrokeColor);
    drawHat(canvasCtx, cx, cy, hatColors);
    drawBike(canvasCtx, cx, cy, circleColors);
}

function drawHead(canvasCtx, cx, cy, circleColors, faceStrokeColor) {
    'use strict';
    var radius = 38;
    drawEllipse(canvasCtx, cx, cy, radius, 0, 360, 1.2);
    applyStyles(canvasCtx, circleColors.fill, circleColors.stroke);

    canvasCtx.strokeStyle = faceStrokeColor;
    canvasCtx.fillStyle = faceStrokeColor;

    // Eyes
    canvasCtx.lineWidth = 1.5;
    drawEllipse(canvasCtx, cx - 50, cy - 10, 5, 0, 360, 1.5);
    canvasCtx.stroke();
    drawEllipse(canvasCtx, cx - 27, cy - 10, 5, 0, 360, 1.5);
    canvasCtx.stroke();

    drawEllipse(canvasCtx, cx + 165, cy - 10, 5, 0, 360, 0.5);
    canvasCtx.fill();
    drawEllipse(canvasCtx, cx + 235, cy - 10, 4, 0, 360, 0.5);
    canvasCtx.fill();

    // Nose
    canvasCtx.moveTo(cx + 22, cy - 10);
    canvasCtx.lineTo(cx + 12, cy + 10);
    canvasCtx.lineTo(cx + 22, cy + 10);
    canvasCtx.stroke();

    // Mouth
    canvasCtx.save();
    canvasCtx.rotate(Math.PI / 17);
    drawEllipse(canvasCtx, cx - 86, cy - 13, 5.5, 0, 360, 3);
    canvasCtx.stroke();
    canvasCtx.restore();
}

function drawHat(canvasCtx, cx, cy, hatColors) {
    'use strict';
    var x = cx - 122;
    var y = cy - 35;
    var radius = 10;

    canvasCtx.lineWidth = 3;
    drawEllipse(canvasCtx, x, y, radius, 0, 360, 5);
    applyStyles(canvasCtx, hatColors.fill, hatColors.stroke);

    canvasCtx.lineWidth = 1.5;
    canvasCtx.fillRect(cx + 8, cy - 95, 50, 60);
    canvasCtx.fill();

    drawCylinder(canvasCtx, cx + 8, cy - 103, 50, 70);
    applyStyles(canvasCtx, hatColors.fill, hatColors.stroke);
}

function drawBike(canvasCtx, cx, cy, circleColors) {
    'use strict';
    var x = cx - 10;
    var y = cy + 150;
    var radius = 38;

    // Wheels
    drawCircle(canvasCtx, x, y, radius, 0, 360);
    applyStyles(canvasCtx, circleColors.fill, circleColors.stroke);

    drawCircle(canvasCtx, x + 160, y, radius, 0, 360);
    applyStyles(canvasCtx, circleColors.fill, circleColors.stroke);

    canvasCtx.lineWidth = 2;

    canvasCtx.moveTo(x, y);
    canvasCtx.lineTo(x + 70, y);

    canvasCtx.moveTo(x, y);
    canvasCtx.lineTo(x + 50, y - 50);
    canvasCtx.lineTo(x + 150, y - 50);
    canvasCtx.lineTo(x + 70, y);
    canvasCtx.lineTo(x + 45, y - 65);

    // Seat
    canvasCtx.moveTo(x + 30, y - 65);
    canvasCtx.lineTo(x + 60, y - 65);

    // Hand drive
    canvasCtx.moveTo(x + 160, y);
    canvasCtx.lineTo(x + 147, y - 80);

    canvasCtx.moveTo(x + 147, y - 80);
    canvasCtx.lineTo(x + 115, y - 70);
    canvasCtx.moveTo(x + 147, y - 80);
    canvasCtx.lineTo(x + 165, y - 105);

    canvasCtx.stroke();

    // Bike pedals
    drawCircle(canvasCtx, x + 70, y, 10, 0, 360);
    canvasCtx.moveTo(x + 63, y - 7);
    canvasCtx.lineTo(x + 55, y - 17);
    canvasCtx.moveTo(x + 77, y + 7);
    canvasCtx.lineTo(x + 85, y + 17);

    canvasCtx.stroke();
}

function drawCircle(canvasCtx, x, y, radius, from, to) {
    canvasCtx.beginPath();
    canvasCtx.arc(x, y, radius, from, to);
}

function drawEllipse(canvasCtx, x, y, radius, from, to, scaleX) {
    'use strict';
    canvasCtx.save();
    canvasCtx.scale(scaleX, 1);
    canvasCtx.beginPath();
    canvasCtx.arc(x, y, radius, from, to);
    canvasCtx.restore();
}

function drawCylinder(canvasCtx, x, y, w, h) {
    'use strict';
    var i, xPos, yPos, pi = Math.PI, twoPi = 2 * pi;

    canvasCtx.beginPath();

    for (i = 0; i < twoPi; i += 0.001) {
        xPos = (x + w / 2) - (w / 2 * Math.cos(i));
        yPos = (y + h / 8) + (h / 8 * Math.sin(i));

        if (i === 0) {
            canvasCtx.moveTo(xPos, yPos);
        } else {
            canvasCtx.lineTo(xPos, yPos);
        }
    }
    canvasCtx.moveTo(x, y + h / 8);
    canvasCtx.lineTo(x, y + h - h / 8);

    for (i = 0; i < pi; i += 0.001) {
        xPos = (x + w / 2) - (w / 2 * Math.cos(i));
        yPos = (y + h - h / 8) + (h / 8 * Math.sin(i));

        if (i === 0) {
            canvasCtx.moveTo(xPos, yPos);
        } else {
            canvasCtx.lineTo(xPos, yPos);
        }
    }
    canvasCtx.moveTo(x + w, y + h / 8);
    canvasCtx.lineTo(x + w, y + h - h / 8);
}

function applyStyles(canvasCtx, fillStyle, strokeStyle) {
    'use strict';
    canvasCtx.fillStyle = fillStyle;
    canvasCtx.strokeStyle = strokeStyle;
    canvasCtx.fill();
    canvasCtx.stroke();
}