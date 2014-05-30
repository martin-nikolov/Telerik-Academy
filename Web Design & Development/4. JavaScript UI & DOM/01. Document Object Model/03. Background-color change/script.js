/*
    3. Crеate a function that gets the value of <input type="color"> 
    and sets the background of the body to this value
*/

taskName = "3. Background-color change";

function Main(bufferElement) {
    SetConsoleSize(100, 700);

    bufferElement.appendChild(createColorInput('backgroundColor'));
}

function createColorInput(eventObj) {
    var textNode = document.createTextNode('Pick a color: ');

    var colorInput = document.createElement('input');
    colorInput.style.marginRight = '5px';
    colorInput.setAttribute('type', 'color');

    var exceptionMsg = document.createElement('span');
    exceptionMsg.innerHTML = '*Enter #FF0000 ("red" or #F00) for IE and Firefox';
    exceptionMsg.style.fontSize = '12px';

    // Set event OnChange content
    colorInput.onchange = function() {
        var body = document.body;
        body.style[eventObj] = colorInput.value;
    };

    var div = document.createElement('div');
    div.style.marginTop = '10px';

    div.appendChild(textNode);
    div.appendChild(colorInput);
    div.appendChild(exceptionMsg);

    return div;
}