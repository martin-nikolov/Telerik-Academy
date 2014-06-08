window.onload = function() {
    var svg = {
        x: 50,
        y: 50,
        width: 440,
        height: 190
    };

    var paper = Raphael(svg.x, svg.y, svg.width, svg.height);

    drawLogo(paper);
};

function drawLogo(paper) {
    drawRect(paper);
    drawText(paper);
}

function drawRect(paper) {
    paper.path('M 99.39 2.50 C 135.59 1.80 171.81 2.11 208.01 2.88 C 220.62 3.54 233.29 3.23 245.87 4.48 C 262.95 6.88 277.32 21.69 279.02 38.89 C 281.43 70.52 281.63 102.32 280.13 134.00 C 279.12 143.31 280.15 153.13 276.13 161.86 C 270.34 175.71 256.06 185.47 241.04 185.77 C 214.36 186.89 187.66 187.60 160.96 187.44 C 148.99 188.15 136.96 188.05 124.99 187.44 C 101.32 187.64 77.67 186.91 54.01 186.16 C 47.91 185.65 41.63 186.14 35.74 184.16 C 21.30 180.01 9.83 166.96 7.86 152.02 C 4.86 114.36 4.92 76.46 7.75 38.79 C 9.59 20.59 25.72 5.06 44.03 4.19 C 62.46 3.18 80.93 2.85 99.39 2.50 Z')
        .attr({
            fill: '#EC2828',
            stroke: '#EC2828'
        })
        .scale(0.8, 0.8)
        .translate(195);
}

function drawText(paper) {
    var x = 100;
    var y = 95;

    paper.text(x, y, 'You')
        .attr({
            'font-size': 83,
            'font-weight': 'bold'
        });

    paper.text(x + 200, y, 'Tube')
        .attr({
            'font-size': 83,
            'font-weight': 'bold',
            fill: 'white'
        });
}