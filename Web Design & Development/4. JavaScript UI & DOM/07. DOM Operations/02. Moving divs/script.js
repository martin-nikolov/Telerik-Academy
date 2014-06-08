/*
    2. Write a script that creates 5 div elements and moves 
    them in circular path with interval of 100 milliseconds
*/

taskName = "2. Moving divs";

function Main(bufferElement) {
    SetConsoleSize(100);

    includeDivs();
}

function includeDivs(count) {
    var count = count || 5;

    var ballContainer = document.createElement('div');
    ballContainer.id = 'ball-container';

    for (var i = 0; i < count; i++) {
        ballContainer.appendChild(generateDiv());
    }

    _GetDefaultContainer().appendChild(ballContainer);

    moveDivs(ballContainer);
}

function moveDivs(ballContainer) {
    var angle = 0, width = 150, height = 150;
    var step = 2 * Math.PI / ballContainer.children.length;

    setNewCoords();

    function setNewCoords() {
        for (var i = 0; i < ballContainer.children.length; i++) {
            var x = Math.cos(angle + (i * step)) * width;
            var y = Math.sin(angle + (i * step)) * height;
        
            ballContainer.children[i].style.left = (x + 420) + 'px';
            ballContainer.children[i].style.top = (y + 300) + 'px';
        }

        angle = (angle + 0.02) % (2 * Math.PI);

        setTimeout(setNewCoords, 7);
    }
}

function generateDiv() {
    var div = document.createElement('div');
    div.style.position = 'absolute';
    div.style.width = '60px';
    div.style.height = '60px';
    div.style.backgroundColor = getRandomRgbColor();
    div.style.borderRadius = '50px';
    return div;
}

function getRandomRgbColor() {
    return 'rgb(' + [GetRandomInt(255), GetRandomInt(255), GetRandomInt(255)].join(',') + ')';
}