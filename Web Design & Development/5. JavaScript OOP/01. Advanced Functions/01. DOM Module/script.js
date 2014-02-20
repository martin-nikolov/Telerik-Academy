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
    // Create simple tree view - Lists with list items and sub-lists
    createHtmlPageNav(bufferElement);

    SetSolveButton(function() {
        var domModule = setDomModule();

        var div = document.createElement("div");
        div.innerHTML = 'div -> domModule.appendChild(div, "#container")';

        // appends div to #content
        domModule.appendChild(div, "#content"); 

        // removes li:first-child from ul
        domModule.removeChild("ul", "li:first-child"); 

        // add handler to each a element with class button
        domModule.addHandler("a.button", 'click',        
                             function() { alert("Clicked") }); 

        // appends 100 divs to buffer, they are displayed in container only when count >= 10
        for (var i = 1; i <= 9; i++) {
            domModule.appendToBuffer("#content", $(div).clone().text('div -> ' + i));
        }

        domModule.appendChild(
            document.createTextNode(
                '9 divs in buffer - must be 10 to be displayed in container...'), '#content')

        domModule.appendToBuffer("#content", $(div).clone().text('div -> 10'));

    }, 'Run DOM Module')
}

function setDomModule() {
    var BUFFER_ELEMENTS = [];
    var MAX_BUFFER_SIZE = 10;

    function _appendChild(element, parentSelector) {
        if (element && parentSelector) {
            $(parentSelector).append(element);
        }
    }

    function _removeChild(parent, elementSelector) {
        if (parent && elementSelector) {
            $(parent).find(elementSelector).remove();
        }
    }

    function _addHandler(element, onEvent, eventFunction) {
        if (element && onEvent && eventFunction) {
            $(element).on(onEvent, eventFunction);
        }
    }

    function _appendToBuffer(parentSelector, element) {
        if (!BUFFER_ELEMENTS[parentSelector]) {
            BUFFER_ELEMENTS[parentSelector] = document.createDocumentFragment();
        }

        $(BUFFER_ELEMENTS[parentSelector]).append(element);

        if (BUFFER_ELEMENTS[parentSelector].childNodes.length === MAX_BUFFER_SIZE) {
            var parent = $(parentSelector);
            $(parent).append(BUFFER_ELEMENTS[parentSelector]);

            $(BUFFER_ELEMENTS[parentSelector]).empty();
        }
    }

    return {
        appendChild: function(element, parentSelector) { _appendChild(element, parentSelector) },
        removeChild: function(parent, elementSelector) { _removeChild(parent, elementSelector) },
        addHandler: function(element, onEvent, eventFunction) { _addHandler(element, onEvent, eventFunction) },
        appendToBuffer: function(parentSelector, element) { _appendToBuffer(parentSelector, element) }
    }
}

function createHtmlPageNav(bufferElement) {
    var div = $('<div/>', {
        id: 'main-nav'
    });

    var ul = $('<ul/>');

    for (var i = 1; i <= 3; i++) {
        var anchor = $('<a/>');
        $(anchor).html('List item ' + i);
        
        var nestedUl = $('<ul/>');

        for (var j = 1; j <= 3; j++) {
            var nestedAnchor = $('<a/>');
            $(nestedAnchor).html('Sub item ' + j);

            if (j == 2) {
                $(nestedAnchor).html('Sub item ' + j + ' - click');
                $(nestedAnchor).addClass('button');
            }

            var nestedLi = $('<li/>');
            $(nestedLi).append(nestedAnchor);
            $(nestedUl).append(nestedLi);
        }

        var li = $('<li/>');
        $(li).append(anchor);
        $(li).append(nestedUl);
        $(ul).append(li);
    }

    $(div).append(ul);
    $(bufferElement).append(div);
}