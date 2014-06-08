/*
    3. Create a text area and two inputs with type="color"
    - Make the font color of the text area as the value of the first color input
    - Make the background color of the text area as the value of the second input
*/

taskName = "3. Color change";

function Main(bufferElement) {
    includeColorInputs(bufferElement);
    includeTextArea(bufferElement);
}

function includeColorInputs(bufferElement) {
    bufferElement.appendChild(createColorInput('color'));
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
        var textArea = document.getElementsByTagName('textarea')[0];
        textArea.style[eventObj] = colorInput.value;
    };

    var div = document.createElement('div');
    div.style.marginTop = '10px';
    div.appendChild(textNode);
    div.appendChild(colorInput);
    div.appendChild(exceptionMsg);

    return div;
}

function includeTextArea(bufferElement) {
    bufferElement.appendChild(createTextArea());
}

function createTextArea() {
    var textArea = document.createElement('textarea');
    textArea.textContent = "Some Text...";
    textArea.style.height = '100px';
    textArea.style.width = '300px';
    textArea.style.marginTop = '10px';
    return textArea;
}