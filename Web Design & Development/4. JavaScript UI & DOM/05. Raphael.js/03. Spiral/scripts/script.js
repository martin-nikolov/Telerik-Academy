window.onload = function() {
    var svg = {
        x: 0,
        y: 0,
        width: 500,
        height: 500
    };

    var paper = Raphael(svg.x, svg.y, svg.width, svg.height);

    drawLogo(paper);
};

//
// Formula: http://stackoverflow.com/questions/6824391/drawing-a-spiral-on-an-html-canvas-using-javascript
//
function drawLogo(paper) {
    var space = 5;
    var scale = 10;
    var centerX = 250;
    var centerY = 250;
    var STEPS_PER_ROTATION = space * 100;
    var increment = 2 * Math.PI / STEPS_PER_ROTATION;
    var angle = increment;

    while (angle < scale * Math.PI) {
        var newX = centerX + (space * angle) * Math.cos(angle);
        var newY = centerY + (space * angle) * Math.sin(angle);
        drawCircle(paper, newX, newY);
        angle += increment;
    }
}

function drawCircle(paper, cx, cy) {
    paper.circle(cx, cy, 1)
        .attr({
            stroke: 'black',
            fill: 'black'
        });
}