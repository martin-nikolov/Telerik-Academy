window.onload = function() {
    var svgNs = 'http://www.w3.org/2000/svg';

    drawScreen(svgNs);
};

function drawScreen(svgNs) {
    var x = 140;
    var y = 115;

    var texts = [
        new Text('M', x, y, 32, '#3E3F37'),
        new Text('E', x + 2, y + 60, 32, '#231F20'),
        new Text('A', x + 1, y + 130, 32, '#E23337'),
        new Text('N', x, y + 200, 32, '#8EC74E')
    ];

    var circles = [
        new Circle(x + 110, y - 15, 60, '#3E3F37'),
        new Circle(x + 110, y + 45, 60, '#282827'),
        new Circle(x + 110, y + 115, 60, '#E23337'),
        new Circle(x + 110, y + 185, 60, '#8EC74E'),
    ];

    drawTexts(svgNs, texts);
    drawCircles(svgNs, circles);
}

function drawTexts(svgNs, texts) {
    for (var i = 0; i < texts.length; i++) {
        drawText(svgNs, texts[i]);
    }
}

function drawText(svgNs, text) {
    var txt = document.createElementNS(svgNs, 'text');
    txt.setAttribute('x', text.x);
    txt.setAttribute('y', text.y);
    txt.setAttribute('fill', text.color);
    txt.setAttribute('font-size', text.size);
    txt.setAttribute('font-family', text.fontFamily);
    txt.setAttribute('font-weight', text.weight);
    var textNode = document.createTextNode(text.content);
    txt.appendChild(textNode);
    document.getElementById('the-svg').appendChild(txt);
}

function drawCircles(svgNs, circles) {
    drawCircle(svgNs, circles[0]);
    drawLeaf(svgNs);

    drawCircle(svgNs, circles[1]);
    drawText(svgNs, new Text('express', circles[1].cx - 53, circles[1].cy + 10, 28, '#FDFDFC', 'Consolas', 'normal'));

    drawCircle(svgNs, circles[2]);
    drawShield(svgNs);

    drawCircle(svgNs, circles[3]);
    drawNodeLogo(svgNs);
}

function drawCircle(svgNs, circle) {
    var c = document.createElementNS(svgNs, 'circle');
    c.setAttribute('cx', circle.cx);
    c.setAttribute('cy', circle.cy);
    c.setAttribute('r', circle.r);
    c.setAttribute('fill', circle.color);
    document.getElementById('the-svg').appendChild(c);
}

function drawLeaf(svgNs) {
    drawPath(svgNs, "M 247.01 75.03 C 248.46 73.86 249.13 72.10 249.86 70.45 C 250.03 70.99 250.37 72.06 250.54 72.59 C 251.67 88.71 250.83 104.88 250.78 121.02 C 250.96 127.04 249.39 133.01 250.20 139.03 C 250.11 138.81 249.93 138.38 249.85 138.16 C 249.57 140.54 249.18 142.90 248.73 145.25 C 238.52 137.40 230.89 125.13 231.19 111.97 C 230.90 98.21 236.54 84.12 247.01 75.03 Z", '#52ac43');

    drawPath(svgNs, " M 250.78 121.02 C 250.83 104.88 251.67 88.71 250.54 72.59 C 251.55 74.47 252.70 76.29 254.19 77.84 C 263.27 86.75 268.62 99.35 268.84 112.06 C 268.95 124.67 262.88 137.03 252.78 144.60 C 251.72 142.84 250.88 140.96 250.20 139.03 C 249.39 133.01 250.96 127.04 250.78 121.02 Z", '#449d36');

    drawPath(svgNs, "M 248.73 145.25 C 249.18 142.90 249.57 140.54 249.85 138.16 C 249.93 138.38 250.11 138.81 250.20 139.03 C 250.88 140.96 251.72 142.84 252.78 144.60 C 251.49 147.92 251.92 151.54 252.15 155.00 L 249.65 155.00 C 249.38 151.75 249.12 148.49 248.73 145.25 Z", '#b7b699');
}

function drawShield(svgNs) {
    var svgId = "shield";
    var svgNs2 = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
    svgNs2.id = svgId;
    svgNs2.setAttribute('xmlns', 'http://www.w3.org/2000/svg');
    svgNs2.setAttribute('x', 212);
    svgNs2.setAttribute('y', 200);
    svgNs2.setAttribute('width', 75);
    svgNs2.setAttribute('height', 80);
    svgNs2.setAttribute('viewBox', '0 0 60 64');
    document.getElementById('the-svg').appendChild(svgNs2);

    drawPath(svgNs, "M 0.34 10.83 C 10.15 7.09 20.15 3.88 29.98 0.20 C 39.83 3.53 49.56 7.25 59.49 10.31 C 58.79 23.43 56.33 36.45 55.30 49.56 C 46.81 54.57 37.78 58.71 29.48 64.00 L 28.45 64.00 C 28.42 63.81 28.36 63.42 28.33 63.22 C 20.61 58.77 12.74 54.55 5.15 49.89 C 3.92 45.58 4.15 41.01 3.33 36.61 C 2.36 28.01 1.12 19.45 0.34 10.83 M 3.09 13.10 C 4.52 24.69 5.74 36.31 7.13 47.91 C 14.45 52.14 21.89 56.15 29.25 60.31 C 36.84 56.26 44.30 51.97 51.82 47.81 C 53.31 36.19 54.84 24.57 56.15 12.92 C 47.14 9.79 38.14 6.61 29.06 3.70 C 20.45 6.97 11.73 9.91 3.09 13.10 Z", '#b3b3b3', svgId);

    drawPath(svgNs, "M 29.35 5.46 C 35.49 19.36 42.17 33.01 48.43 46.84 C 46.30 46.82 44.17 46.80 42.04 46.78 C 40.57 43.65 39.24 40.46 37.82 37.30 C 34.99 37.35 32.16 37.37 29.33 37.33 C 29.31 35.51 29.30 33.68 29.28 31.86 C 31.34 31.85 33.39 31.85 35.45 31.84 C 33.53 27.43 31.30 23.16 29.34 18.78 C 29.45 14.81 29.44 10.82 28.96 6.87 C 29.06 6.52 29.25 5.82 29.35 5.46 Z", '#b3b3b3', svgId);

    drawPath(svgNs, "M 29.06 3.70 C 38.14 6.61 47.14 9.79 56.15 12.92 C 54.84 24.57 53.31 36.19 51.82 47.81 C 44.30 51.97 36.84 56.26 29.25 60.31 C 29.33 52.65 29.24 44.99 29.33 37.33 C 32.16 37.37 34.99 37.35 37.82 37.30 C 39.24 40.46 40.57 43.65 42.04 46.78 C 44.17 46.80 46.30 46.82 48.43 46.84 C 42.17 33.01 35.49 19.36 29.35 5.46 C 29.28 5.02 29.13 4.14 29.06 3.70 Z", '#b92933', svgId);

    drawPath(svgNs, "M 11.02 46.75 C 17.01 33.46 22.75 20.06 28.96 6.87 C 29.44 10.82 29.45 14.81 29.34 18.78 C 29.22 19.17 28.98 19.96 28.86 20.35 C 27.10 24.13 25.53 28.00 23.97 31.87 C 25.74 31.86 27.51 31.86 29.28 31.86 C 29.30 33.68 29.31 35.51 29.33 37.33 C 26.72 37.27 24.11 37.27 21.51 37.29 C 20.30 40.42 19.09 43.54 17.75 46.61 C 15.51 46.64 13.26 46.69 11.02 46.75 Z", '#f2f2f2', svgId);

    drawPath(svgNs, "M 29.34 18.78 C 31.30 23.16 33.53 27.43 35.45 31.84 C 33.39 31.85 31.34 31.85 29.28 31.86 C 29.44 28.01 29.34 24.17 28.86 20.35 C 28.98 19.96 29.22 19.17 29.34 18.78 Z", '#b82934', svgId);
}

function drawNodeLogo(svgNs) {
    var svgId = "node-logo";
    var svgNs2 = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
    svgNs2.id = svgId;
    svgNs2.setAttribute('xmlns', 'http://www.w3.org/2000/svg');
    svgNs2.setAttribute('x', 204);
    svgNs2.setAttribute('y', 280);
    svgNs2.setAttribute('width', 95);
    svgNs2.setAttribute('height', 34);
    svgNs2.setAttribute('viewBox', '0 0 125 45');
    document.getElementById('the-svg').appendChild(svgNs2);
  
    drawPath(svgNs, "M 83.57 0.00 L 84.38 0.00 C 86.81 1.35 89.32 2.62 91.54 4.31 C 92.02 5.81 91.89 7.41 91.94 8.96 C 91.82 18.57 91.99 28.18 91.85 37.80 C 87.97 40.46 83.61 42.31 79.76 45.00 L 78.42 45.00 C 74.95 42.09 70.67 40.39 66.91 37.90 C 66.96 33.25 66.62 28.59 67.01 23.95 C 70.45 20.72 75.19 19.10 79.09 16.42 C 80.52 17.09 81.95 17.76 83.38 18.42 C 83.72 12.29 83.44 6.14 83.57 0.00 M 75.23 28.26 C 75.18 29.84 75.14 31.43 75.10 33.01 C 76.44 33.82 77.78 34.65 79.10 35.50 C 80.58 34.73 82.03 33.93 83.47 33.10 C 83.43 31.42 83.37 29.75 83.29 28.08 C 81.91 27.38 80.53 26.68 79.15 25.97 C 77.85 26.74 76.54 27.51 75.23 28.26 Z", '#47493e', svgId);
    
    drawPath(svgNs, "M 12.32 16.19 C 16.75 17.98 20.67 20.87 24.85 23.18 C 24.81 29.50 24.89 35.81 24.78 42.12 C 22.09 40.52 18.79 39.53 16.79 37.04 C 16.45 34.14 16.87 31.21 16.53 28.32 C 15.30 26.58 12.58 24.95 10.57 26.51 C 6.15 28.45 9.13 34.08 7.82 37.70 C 5.44 39.58 2.59 40.71 0.00 42.25 L 0.00 23.28 C 4.06 20.85 8.08 18.31 12.32 16.19 Z", '#47493e', svgId);

    drawPath(svgNs, "M 100.30 23.31 C 104.45 20.89 108.56 18.38 112.83 16.18 C 116.85 18.64 121.03 20.86 125.00 23.40 L 125.00 27.96 C 122.39 29.58 119.71 31.09 116.98 32.50 C 116.91 31.03 116.83 29.57 116.77 28.10 C 115.49 27.33 114.22 26.53 112.87 25.90 C 111.15 26.23 109.75 27.37 108.25 28.19 C 108.29 29.68 108.27 31.17 108.46 32.65 C 111.95 35.94 117.02 37.02 120.38 40.51 C 118.01 41.83 115.38 42.90 113.56 45.00 L 112.41 45.00 C 108.66 42.12 104.24 40.30 100.27 37.75 C 100.15 32.93 100.14 28.12 100.30 23.31 Z", '#47493e', svgId);

    drawPath(svgNs, "M 33.42 23.26 C 37.52 20.70 41.73 18.33 45.94 15.95 C 50.11 18.26 54.19 20.72 58.35 23.05 C 58.55 28.00 58.52 32.95 58.36 37.90 C 54.43 40.21 50.28 42.19 46.67 45.00 L 46.24 45.00 C 41.81 42.86 37.64 40.25 33.43 37.71 C 33.39 32.89 33.40 28.08 33.42 23.26 Z", '#ffffff', svgId);

    drawPath(svgNs, "M 110.18 29.09 C 111.04 28.60 111.91 28.11 112.77 27.62 C 113.35 27.97 114.50 28.67 115.08 29.02 C 115.09 29.75 115.11 31.20 115.11 31.93 C 114.54 32.27 113.38 32.96 112.81 33.30 C 111.94 32.85 111.08 32.39 110.22 31.94 C 110.21 31.23 110.19 29.80 110.18 29.09 Z", '#ffffff', svgId);
}

function drawPath(svgNs, d, fillColor, svgId) {
    svgId = svgId || "the-svg";
    var path = document.createElementNS(svgNs, 'path');
    path.setAttribute('d', d);
    path.setAttribute('fill', fillColor);
    path.setAttribute('stroke', 'none');
    document.getElementById(svgId).appendChild(path);
}

function Text(content, x, y, size, color, fontFamily, weight) {
    this.content = content;
    this.x = x;
    this.y = y;
    this.size = size;
    this.color = color;
    this.fontFamily = fontFamily || 'Verdana';
    this.weight = weight || 'bold';

    return this;
}

function Circle(cx, cy, r, color) {
    this.cx = cx;
    this.cy = cy;
    this.r = r;
    this.color = color;

    return this;
}