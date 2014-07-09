/*!
* jsConsole Library - https://github.com/flextry/jsConsole
*
* Copyright 2014 Martin Nikolov
* Released under the MIT license
*
* jsConsole Library © Martin Nikolov - Version [0.4] 
*/

var taskName = "JavaScript Console";
var message = "";

//
// Internal Methods ('private methods' automatically executed on window load)
//
window.onload = function () {
    _ChangeTitleAndMessage();
    _ExecuteExternalScript(document.getElementById('content'));
    _SetFocusToFirstInput();
    _SetOnEnterClickEvent();
}

function _ChangeTitleAndMessage() {
    document.getElementById('title').innerHTML = taskName;
    // Original
    // document.getElementById('content').innerHTML = message;

    // Small modification only for current task (fixed bug in Firefox)
    var innerHTML = document.getElementById('content').innerHTML;
    document.getElementById('content').innerHTML = innerHTML.substr(innerHTML.indexOf('</a>'));
    
    document.title = taskName;
}

function _ExecuteExternalScript(onHtmlElement) {
    var content = onHtmlElement;

    // You call your functions in Main method
    // that is placed in your .js file
    Main(content);
}

function _SetOnEnterClickEvent() {
    if (document.layers) {
        document.captureEvents(Event.KEYDOWN);
    }

    document.onkeydown = function (e) {
        var keyCode = e ? (e.which ? e.which : e.keyCode) : event.keyCode;

        if (keyCode == 13) {
            FocusNextEmptyInput();
            ActivateEnterButton();
        }

        function FocusNextEmptyInput() {
            var inputs = document.getElementsByTagName('input');

            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].value == "") {
                    inputs[i].focus();
                    break;
                }
            }
        }

        function ActivateEnterButton() {
            var inputs = document.getElementsByTagName('input');
            var hasEmptyInput = false;

            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].value == "") {
                    hasEmptyInput = true;
                    break;
                }
            }

            if (!hasEmptyInput) {
                document.getElementsByClassName('solve-button')[0].focus();
            }
        }
    }
}

function _SetFocusToFirstInput() {
    var firstInput = document.querySelector("input[type=text]:first-of-type");

    if (firstInput && firstInput.value.length == 0) {
        firstInput.focus();
    }
}

function _InsertLineBreaks() {
    var content = document.getElementById('result-container');

    if (content) {
        var oldContent = content.innerHTML;
        var newContent = oldContent.replace(/_br_/gi, "<br>");
        content.innerHTML = newContent;    
    }
}

function _EscapeBrTags(message) {
    return message.toString().replace(/<br\s*[\/]?>/gi, '_br_');
}

function _GetDefaultContainer() {
    var container1 = document.getElementById('result-container');
    var container2 = document.getElementById('content');

    if (container1) {
        return container1;
    }
    else if (container2) {
        return container2;
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
function filterNumber(element) {
    var number = parseFloat(element);

    if (IsNumber(number)) {
        return new Number(number);
    }
}

function SplitBySeparator(string, separators) {
    separators = typeof separators !== 'undefined' ? separators : " ";

    if (Array.isArray(separators)) {
        string = string.split(new RegExp(separators.join('|'), 'g'));
    }
    else {
        string = string.split(separators);
    }

    return string.filter(String);
}

function ParseIntCollection(string, separators) {
    string = SplitBySeparator(string, separators);
    return ParseElementsToInt(string).filter(filterNumber);
}

function ParseFloatCollection(string, separators) {
    string = SplitBySeparator(string, separators);
    return ParseElementsToFloat(string).filter(filterNumber);
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
    WriteToElement(message, _GetDefaultContainer());
}

function WriteLine(message) {
    WriteLineToElement(message, _GetDefaultContainer());
}

function WriteToElement(message, toElement) {
    try {
        message = message.toString();
    }
    catch(e) {
        message = "";
    }

    if (message && toElement) {
        var messageWithEscapedBrTags = _EscapeBrTags(message);

        var textBlock = document.createTextNode(messageWithEscapedBrTags);
        toElement.appendChild(textBlock);

        if (message != messageWithEscapedBrTags) {
            _InsertLineBreaks();
        }
    }
}

function WriteLineToElement(message, toElement) {
    WriteToElement(message, toElement);

    var container = _GetDefaultContainer();
    container.appendChild(document.createElement("br"));
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

    if (defaultValue || defaultValue == 0) {
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
    button.id = "btn";

    var resultContainer = document.createElement('div');
    resultContainer.id = 'result-container';

    if (toElement) {
        toElement.appendChild(button);
        toElement.appendChild(resultContainer);
    }
    else {
        document.getElementById('content').appendChild(button);
        document.getElementById('content').appendChild(resultContainer);
    }
}

//
// Math
//
function GetRandomInt(min, max) {
    min = parseInt(min);
    max = parseInt(max);

    if (!IsNumber(min)) {
        return 0;
    }

    if (!IsNumber(max)) {
        max = min;
        min = 0;
    }

    if (min > max) {
        return 0;
    }

    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function GetRandomFloat(min, max, toFixed) {
    toFixed = typeof toFixed !== 'undefined' ? toFixed : 2;

    min = parseInt(min);
    max = parseInt(max);

    if (!IsNumber(min)) {
        return 0;
    }

    if (!IsNumber(max)) {
        max = min;
        min = 0;
    }

    if (min > max) {
        return 0;
    }

    return (Math.random() * (max - min) + min).toFixed(toFixed);
}

function IsNumber(n) {
  return !isNaN(parseFloat(n)) && isFinite(n);
}

//
// Console Clear Method
//
function ConsoleClear() {
    var container = _GetDefaultContainer();

    ClearElementChildren(container);
}

function ClearElementChildren(htmlElement) {
    if (!htmlElement) {
        return;
    }

    while (htmlElement.firstChild) {
        htmlElement.removeChild(htmlElement.firstChild);
    }
}