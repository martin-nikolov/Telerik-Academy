// jsConsole Library © Martin Nikolov - Version [0.1] 

var taskName = "JavaScript Console";
var message = "";

//
// Internal Methods ('private methods' automatically executed on window load)
//
window.onload = function () {
    ChangeTitleAndMessage();
    ExecuteExternalScript(document.getElementById('content'));
    SetFocusToFirstInput();
}

function ChangeTitleAndMessage() {
    document.getElementById('title').innerHTML = taskName;
    document.getElementById('content').innerHTML = message;
}

function ExecuteExternalScript(onHtmlElement) {
    var content = onHtmlElement;

    // You call your functions in Main method
    // that is placed in your .js file
    Main(content);
}

function SetFocusToFirstInput() {
    var firstInput = document.querySelector("input[type=text]:first-of-type");

    if (firstInput && firstInput.value.length == 0) {
        firstInput.focus();
    }
}

//
// Library Methods ('public methods' you can use)
//
function SetFontSize(pixels) {
    pixels = typeof pixels !== 'undefined' ? pixels : "15px";
    pixels = AccumulatePixels(pixels, 0);

    document.getElementById('content').style.fontSize = pixels;
}

function SetConsoleSize(height, width) {
    height = typeof height !== 'undefined' ? height + "px" : "400px";
    width = typeof width !== 'undefined' ? width + "px" : "850px";

    document.getElementById("main-container").style.height = height;
    document.getElementById("main-container").style.width = width;
    document.getElementById("inner-container").style.height = AccumulatePixels(height, -33);
    document.getElementById("console-container").style.height = AccumulatePixels(height, 300);
}

function AccumulatePixels(px1, px2) {
    return (parseInt(px1, 10) + parseInt(px2, 10)) + "px";
}

//
// Collection elements Parser
//
// var separators = [' ', '\{', '-', '\}', '\\\)', '\\*', '/', ':', '\\\?'];
// numbers = ParseFloatCollection(numbers, new RegExp(separators.join('|'), 'g'));
function SplitBySeparator(string, separators) {
    separators = typeof separators !== 'undefined' ? separators : " ";
    string = string.value.split(separators);
    return string;
}

function ParseIntCollection(string, separators) {
    string = SplitBySeparator(string, separators);
    return ParseElementsToInt(string).filter(Number);
}

function ParseFloatCollection(string, separators) {
    string = SplitBySeparator(string, separators);
    return ParseElementsToFloat(string).filter(Number);
}

function ParseStringCollection(string, separators) {
    string = SplitBySeparator(string, separators);
    return string.filter(String);
}

function ParseElementsToInt(collection) {
    var result = collection.map(function (x) {
        return parseInt(x, 10);
    });

    return result;
}

function ParseElementsToFloat(collection) {
    var result = collection.map(function (x) {
        return parseFloat(x, 10);
    });

    return result;
}

//
// Console Writing Methods
//
function Write(message) {
    WriteToElement(message, document.getElementById('content'));
}

function WriteLine(message) {
    WriteLineToElement(message, document.getElementById('content'));
}

function WriteToElement(message, toElement) {
    if (message && toElement) {
        var textBlock = document.createTextNode(message);
        toElement.appendChild(textBlock);
    }
}

function WriteLineToElement(message, toElement) {
    WriteToElement(message, toElement);
    toElement.appendChild(document.createElement("br"));
}

function Format(str) {
    var selfArguments = arguments;

    return str.replace(/\{(\d+)\}/g, function (match, arg) {
        return selfArguments[+arg + 1];
    })
}

//
// Console Reading Methods
//
function ReadLine(textMessage, defaultValue, idName) {
    return ReadLineFromElement(null, textMessage, defaultValue, idName);
}

function ReadLineFromElement(fromElement, textMessage, defaultValue, idName) {
    var textBlock = document.createTextNode(textMessage);

    var textBox = document.createElement('input');
    textBox.setAttribute('type', 'text');

    if (defaultValue) {
        textBox.value = defaultValue;
    }

    if (idName) {
        textBox.id = idName;
    }

    var label = document.createElement('label');
    label.style.display = 'inline-block';
    label.appendChild(textBlock);
    label.appendChild(textBox);

    var blockElement = document.createElement('div');
    blockElement.appendChild(label);

    if (fromElement) {
        fromElement.appendChild(blockElement);
    }
    else {
        document.getElementById('content').appendChild(blockElement);
    }

    return textBox;
}

//
// Set Solve Problems Button Methods
//
function SetSolveButton(events, textMessage) {
    SetSolveButtonToElement(null, events, textMessage);
}

function SetSolveButtonToElement(toElement, events, textMessage) {
    textMessage = typeof textMessage !== 'undefined' ? textMessage : "Solve";

    var button = document.createElement('button');
    button.className = 'solve-button';
    button.innerHTML = textMessage;
    button.onclick = events;

    if (toElement) {
        toElement.appendChild(button);
    }
    else {
        document.getElementById('content').appendChild(button);
    }
}