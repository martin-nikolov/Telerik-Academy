window.onload = function() {
    var svg = {
        x: 50,
        y: 50,
        width: 450,
        height: 150
    };

    var paper = Raphael(svg.x, svg.y, svg.width, svg.height);

    drawLogo(paper);
};

function drawLogo(paper) {
    drawSymbol(paper);
    drawText(paper);
}

function drawSymbol(paper) {
    paper.path('M 31.52 3.48 C 40.30 12.14 48.88 20.99 57.72 29.58 C 66.36 20.90 74.96 12.19 83.70 3.62 C 92.41 12.29 101.07 21.00 109.77 29.69 C 106.31 33.04 102.92 36.47 99.55 39.91 C 94.19 34.81 89.03 29.50 83.83 24.23 C 78.45 29.37 73.32 34.76 67.99 39.94 C 76.65 48.64 85.31 57.34 94.03 65.98 C 82.00 78.15 69.78 90.12 57.83 102.36 C 45.39 90.52 33.46 78.12 21.27 66.00 C 29.97 57.40 38.50 48.64 47.17 40.01 C 42.18 34.62 36.73 29.67 31.73 24.29 C 26.33 29.39 21.22 34.77 15.93 39.98 C 12.31 36.67 9.04 33.01 5.42 29.70 C 14.10 20.93 22.91 12.30 31.52 3.48 M 41.96 65.99 C 47.18 71.26 52.39 76.53 57.69 81.71 C 62.82 76.39 68.14 71.26 73.30 65.97 C 68.06 60.80 62.82 55.62 57.70 50.33 C 52.39 55.49 47.25 60.81 41.96 65.99 Z')
        .attr({
            fill: '#5ce600',
            stroke: '#5ce600'
        })
        .scale(0.8, 0.8);
}

function drawText(paper) {
    var x = 235;
    var y = 63;

    paper.text(x, y, 'Telerik')
        .attr({
            'font-size': 80,
            'font-weight': 'bold'
        });

    paper.text(x + 14, y + 45, 'Develop experiences')
        .attr({
            'font-size': 27,
            'font-weight': '10'
        });

    paper.text(x + 140, y - 5, '®')
        .attr({
            'font-size': 25,
            'font-weight': 'bold'
        });
}