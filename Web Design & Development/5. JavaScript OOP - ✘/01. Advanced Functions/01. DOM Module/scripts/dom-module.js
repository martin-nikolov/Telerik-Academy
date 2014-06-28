var DomModule = (function() {
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
        appendChild: _appendChild,
        removeChild: _removeChild,
        addHandler: _addHandler,
        appendToBuffer: _appendToBuffer
    }
})();