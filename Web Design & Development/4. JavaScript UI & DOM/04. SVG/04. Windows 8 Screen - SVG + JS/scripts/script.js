window.onload = function() {
    var svgNs = 'http://www.w3.org/2000/svg';

    drawScreen(svgNs);
};

function drawScreen(svgNs) {
    var rows = {
        0: [
            new Figure('quad', '#2C85ED'),
            new Figure('quad', '#5BA618'),
            new Figure('rect', '#AA2039'),
            new Figure('rect', '#008D15'),
            new Figure('rect', '#593E9B'),
            new Figure('quad', 'none')
        ],
        1: [
            new Figure('quad', '#593E9B'),
            new Figure('quad', '#3B6EEB'),
            new Figure('rect', '#593E9B'),
            new Figure('rect', '#D9512B'),
            new Figure('rect', '#008C1B'),
            new Figure('quad', 'none')
        ],
        2: [
            new Figure('rect', '#D44A26'),
            new Figure('rect', '#019317'),
            new Figure('quad', 'none'),
            new Figure('quad', 'none'),
            new Figure('quad', '#D04C26'),
            new Figure('quad', '#00245E'),
            new Figure('quad', '#2877ED')
        ],
        3: [
            new Figure('rect', 'none'),
            new Figure('rect', '#3D84EE'),
            new Figure('quad', '#AB1F3A'),
            new Figure('quad', '#54A61D'),
            new Figure('rect', 'none')
        ],

        startX: 95,
        startY: 145,
        numOfRows: 4
    };

    var x = rows.startX;
    var y = rows.startY;

    var images = [
        new Image(x + 820, y - 122, 44, 52, 'images/0.jpg'),

        new Image(x + 25, y + 17, 44, 52, 'images/1.jpg'),
        new Image(x + 110, y + 15, 73, 60, 'images/2.jpg'),
        new Image(x + 265, y + 15, 66, 65, 'images/3.jpg'),
        new Image(x + 710, y + 15, 63, 65, 'images/4.jpg'),
        new Image(x + 840, y, 70, 95, 'images/22.jpg'),

        new Image(x + 20, y + 110, 52, 65, 'images/5.jpg'),
        new Image(x + 112, y + 112, 69, 60, 'images/6.jpg'),
        new Image(x + 262, y + 115, 72, 60, 'images/7.jpg'),
        new Image(x + 410, y + 110, 52, 52, 'images/8.jpg'),
        new Image(x + 710, y + 115, 61, 60, 'images/9.jpg'),
        new Image(x + 840, y + 100, 70, 95, 'images/10.jpg'),

        new Image(x + 70, y + 230, 54, 36, 'images/11.jpg'),
        new Image(x + 400, y + 200, 95, 95, 'images/12.jpg'),
        new Image(x + 500, y + 200, 96, 95, 'images/13.jpg'),
        new Image(x + 662, y + 215, 55, 60, 'images/14.jpg'),
        new Image(x + 752, y + 265, 28, 24, 'images/15.jpg'),
        new Image(x + 860, y + 225, 50, 42, 'images/16.jpg'),

        new Image(x, y + 295, 195, 105, 'images/17.jpg'),
        new Image(x + 265, y + 315, 61, 60, 'images/18.jpg'),
        new Image(x + 417, y + 318, 61, 60, 'images/19.jpg'),
        new Image(x + 517, y + 317, 61, 60, 'images/20.jpg'),
        new Image(x + 640, y + 300, 195, 95, 'images/21.jpg')
    ];

    var texts = [
        new Text('Start', x, y - 90, 45, '#FCFFFF'),
        new Text('Richard', x + 750, y - 100, 20, '#C1CDD9'),
        new Text('Perry', x + 781, y - 80, 15, '#C1CDD9'),

        new Text('Store', x + 15, y + 87, 10, '#F6FDFF'),
        new Text('Xbox Games', x + 115, y + 87, 10, '#F6FDFF'),
        new Text('Photos', x + 215, y + 87, 10, '#F6FDFF'),
        new Text('Calendar', x + 415, y + 87, 10, '#F6FDFF'),
        new Text('12', x + 525, y + 50, 50, '#F6FDFF'),
        new Text('Monday', x + 535, y + 65, 10, '#F6FDFF'),
        new Text('Music', x + 655, y + 87, 10, '#F6FDFF'),

        new Text('Maps', x + 15, y + 187, 10, '#F6FDFF'),
        new Text('Internet Explorer', x + 108, y + 187, 10, '#F6FDFF'),
        new Text('Messaging', x + 215, y + 187, 10, '#F6FDFF'),
        new Text('Mike Gibbs, Troll Scout', x + 470, y + 125, 10, '#F6FDFF'),
        new Text('and 5 others commented', x + 470, y + 140, 10, '#F6FDFF'),
        new Text('on your photo.', x + 470, y + 155, 10, '#F6FDFF'),
        new Text('Finance', x + 655, y + 187, 10, '#F6FDFF'),

        new Text('Video', x + 15, y + 287, 10, '#F6FDFF'),
        new Text('Devon Hypnotize', x + 215, y + 227, 18, '#F6FDFF'),
        new Text('something they can do about him', x + 215, y + 242, 10, '#F6FDFF'),
        new Text('pile of books and scrollsnext to', x + 215, y + 255, 10, '#F6FDFF'),
        new Text('3', x + 375, y + 287, 12, '#F6FDFF'),
        new Text('Reader', x + 655, y + 287, 10, '#F6FDFF'),
        new Text('Window', x + 760, y + 227, 16, '#6188CB'),
        new Text('Explorer', x + 760, y + 245, 14, '#6188CB'),
        new Text('SkyDrive', x + 855, y + 287, 10, '#F6FDFF'),

        new Text('Desktop', x + 15, y + 387, 10, '#F6FDFF'),
        new Text('Weather', x + 215, y + 387, 10, '#F6FDFF'),
        new Text('Camera', x + 415, y + 387, 10, '#F6FDFF'),
        new Text('Xbox Comparison', x + 507, y + 387, 10, '#F6FDFF')
    ];

    drawRectangles(svgNs, rows);
    drawImages(svgNs, images);
    drawTexts(svgNs, texts);
}

function drawRectangles(svgNs, rows) {
    var y = rows.startY;
    var step = 5;

    for (var i = 0; i < rows.numOfRows; i++) {
        var x = rows.startX;

        for (var j = 0; j < rows[i].length; j++) {
            if (j === 4) {
                x += 40;
            }

            drawRect(svgNs, x, y, rows[i][j]);
            x += rows[i][j].width + step;
        }

        y += 95 + step;
    }
}

function drawRect(svgNs, x, y, figure) {
    var rect = document.createElementNS(svgNs, 'rect');
    rect.setAttribute('x', x);
    rect.setAttribute('y', y);
    rect.setAttribute('width', figure.width);
    rect.setAttribute('height', figure.height);
    rect.setAttribute('fill', figure.fillColor);
    document.getElementById('the-svg').appendChild(rect);
}

function drawImages(svgNs, images) {
    for (var i = 0; i < images.length; i++) {
        drawImage(svgNs, images[i]);
    }
}

function drawImage(svgNs, image) {
    var img = document.createElementNS(svgNs, 'image');
    img.setAttribute('x', image.x);
    img.setAttribute('y', image.y);
    img.setAttribute('width', image.width);
    img.setAttribute('height', image.height);
    img.setAttributeNS('http://www.w3.org/1999/xlink', 'href', image.src);
    document.getElementById('the-svg').appendChild(img);
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
    txt.setAttribute('font-family', 'Segoe UI');
    var textNode = document.createTextNode(text.content);
    txt.appendChild(textNode);
    document.getElementById('the-svg').appendChild(txt);
}

function Figure(type, fillColor, img) {
    var size = getSize(type);

    this.width = size.width;
    this.height = size.height;
    this.fillColor = fillColor;
    this.img = img;

    return this;
}

function Image(x, y, width, height, src) {
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
    this.src = src;

    return this;
}

function Text(content, x, y, size, color) {
    this.content = content;
    this.x = x;
    this.y = y;
    this.size = size;
    this.color = color;

    return this;
}

function getSize(type) {
    var quadrat = {
        width: 95,
        height: 95
    };

    var rect = {
        width: 195,
        height: 95
    };

    if (type === 'rect') {
        return rect;
    } else {
        return quadrat;
    }
}