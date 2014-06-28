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
    createSimpleTreeView(bufferElement);

    var domModule = DomModule; // DomModule is global object (see dom-module.js)

    SetSolveButton(function() {
        var div = $("<div/>").text('div -> domModule.appendChild(div, "#container")');

        domModule.appendChild(div, "#content"); // appends div to #content
        domModule.removeChild("ul", "li:first-child"); // removes li:first-child from ul

        // add handler to each a element with class button
        domModule.addHandler("a.button", 'click', function() {
            alert("Clicked")
        });

        // appends 100 divs to buffer, they are displayed in container only when count >= 10
        for (var i = 1; i <= 9; i++) {
            domModule.appendToBuffer("#content", $(div).clone().text('div -> ' + i));
        }

        domModule.appendChild(
            document.createTextNode(
                '9 divs in buffer - must be 10 to be displayed in container...'), '#content')

        // Appends elements to buffer using documentFragment
        domModule.appendToBuffer("#content", $(div).clone().text('div -> the 10th'));

    }, 'Run DOM Module')
}

// Creates simple tree view - Lists with list items and sub-lists
function createSimpleTreeView(container) {
    var treeViewUl = $('<ul/>');

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
        $(treeViewUl).append(li);
    }

    var treeViewWrapper = $('<div/>')
        .attr('id', 'main-nav')
        .append(treeViewUl);

    $(container).append(treeViewWrapper);
}