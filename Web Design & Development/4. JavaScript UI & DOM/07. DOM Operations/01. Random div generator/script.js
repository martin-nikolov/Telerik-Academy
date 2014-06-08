/*
    1. Write a script that creates a number of div elements. Each div element must have the following
    - Random width and height between 20px and 100px
    - Random background color
    - Random font color
    - Random position on the screen (position:absolute)
    - A strong element with text "div" inside the div
    - Random border radius
    - Random border color
    - Random border width between 1px and 20px
*/

taskName = "1. Random div generator";

var borderStyles = [
    "dotted",
    "dashed",
    "solid",
    "double",
    "groove",
    "ridge",
    "inset",
    "outset"
];

function Main(bufferElement) {
    SetConsoleSize(100);

    var inputCount = ReadLine("Number of divs: ", GetRandomInt(20, 100));

    SetSolveButton(function() {
        ConsoleClear();

        var numberOfDivs = inputCount.value | 0;
        includeDivs(numberOfDivs);
    });
}

function includeDivs(count) {
    var count = count || 5;
    var maxElements = 20000;
    var documentFragment = document.createDocumentFragment();

    for (var i = 0; i < count && count < maxElements; i++) {
        documentFragment.appendChild(generateDiv());
    }

    _GetDefaultContainer().appendChild(documentFragment);
}

function generateDiv() {
    var div = document.createElement('div');

    div.style.position = 'absolute';

    div.style.width = getRandomPixelValue(20, 100);
    div.style.height = getRandomPixelValue(20, 100);
    div.style.lineHeight = div.style.height;

    div.style.backgroundColor = getRandomRgbColor();
    div.style.color = getRandomRgbColor();

    div.style.borderStyle = getRandomBorderStyle();
    div.style.borderRadius = getRandomPixelValue(100);
    div.style.borderColor = getRandomRgbColor();
    div.style.borderWidth = getRandomPixelValue(1, 20);

    var container = _GetDefaultContainer();

    div.style.left = getRandomPixelValue(container.offsetWidth);
    div.style.top = getRandomPixelValue(150, container.offsetHeight + 500);

    div.style.overflow = 'hidden';
    div.appendChild(generateInnerContent());
    return div;
}

function getRandomPixelValue(from, to) {
    return GetRandomInt(from, to) + 'px';
}

function getRandomRgbColor() {
    return 'rgb(' + [GetRandomInt(255), GetRandomInt(255), GetRandomInt(255)].join(',') + ')';
}

function getRandomBorderStyle() {
    var randomIndex = GetRandomInt(borderStyles.length - 1);
    return borderStyles[randomIndex];
}

function generateInnerContent() {
    var strongElement = document.createElement('strong');
    strongElement.style.textAlign = 'center';
    strongElement.style.display = 'block';
    strongElement.innerHTML = 'div';
    return strongElement;
}