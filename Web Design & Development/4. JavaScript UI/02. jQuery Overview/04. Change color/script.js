/*
    4. Implement functionality to change the background color of a web page
    * i.e. select a color from a color picker and set
      this color as the background color of the page
*/

taskName = "4. Color change";

function Main(bufferElement) {

    includeColorInputs(bufferElement);
}

function includeColorInputs(bufferElement) {
    var consoleContainer = $('#inner-container')[0];
    $(bufferElement).append(createColorInput('background-color',  consoleContainer));

    var documentContainer = $(document.body)[0];
    $(bufferElement).append(createColorInput('background-color', documentContainer));
}

function createColorInput(propertyChange, element) {
    var textNode = $(document.createTextNode('Pick a color: '));

    var colorInput = $('<input/>');
    $(colorInput).attr('type', 'color');
    $(colorInput).addClass('color-picker');

    var exceptionMsg = $('<span/>');
    $(exceptionMsg).addClass('exception-msg');
    $(exceptionMsg).text('*Enter #FF0000 ("red" or #F00) for IE and Firefox');

    // Set event OnChange content
    $(colorInput).on('change', function() {
        $(element).css(propertyChange, $(colorInput).val());
    });

    var div = $('<div/>');
    $(div).addClass('color-picker-container');

    $(div).append(textNode);
    $(div).append(colorInput);
    $(div).append(exceptionMsg);

    return div;
}