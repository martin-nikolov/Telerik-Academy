/*
    1. Create a module for working with DOM. 
       The module should have the following functionality:

    - Add DOM element to parent element given by selector
    - Remove element from the DOM  by given selector
    - Attach event to given selector by given event type and event handler
    - Add elements to buffer, which appends them to the DOM when their 
      count for some selector becomes 100
    - The buffer contains elements for each selector it gets
    - Get elements by CSS selector
    * The module should reveal only the methods
*/

taskName = "1. DOM Module";

function Main(bufferElement) {
    createHtmlPageNav(bufferElement); // Create simple tree view - Lists with list items and sub-lists

    var domModule = DomModule;

    SetSolveButton(function() {
        var div = $("<div/>").text('div -> domModule.appendChild(div, "#container")');

        domModule.appendChild(div, "#content"); // appends div to #content
        domModule.removeChild("ul", "li:first-child"); // removes li:first-child from ul

        // add handler to each a element with class button
        domModule.addHandler("a.button", 'click', function() { alert("Clicked") }); 

        // appends 100 divs to buffer, they are displayed in container only when count >= 10
        for (var i = 1; i <= 9; i++) {
            domModule.appendToBuffer("#content", $(div).clone().text('div -> ' + i));
        }

        domModule.appendChild(
            document.createTextNode(
                '9 divs in buffer - must be 10 to be displayed in container...'), '#content')

        domModule.appendToBuffer("#content", $(div).clone().text('div -> the 10th'));

    }, 'Run DOM Module')
}

function createHtmlPageNav(bufferElement) {
    var ul = $('<ul/>');

    for (var i = 1; i <= 3; i++) {
        var anchor = $('<a/>').html('List item ' + i);
        var nestedUl = $('<ul/>');

        for (var j = 1; j <= 3; j++) {
            var nestedAnchor = $('<a/>').html('Sub item ' + j);

            if (j == 2) {
                $(nestedAnchor).html('Sub item ' + j + ' - click').addClass('button');
            }

            var nestedLi = $('<li/>').append(nestedAnchor);
            $(nestedUl).append(nestedLi);
        }

        var li = $('<li/>').append(anchor).append(nestedUl);
        $(ul).append(li);
    }

    var navWrapper = $('<div/>')
        .attr('id', 'main-nav')
        .append(ul);

    $(bufferElement).append(navWrapper);
}