/*
    2. Using jQuery implement functionality to insert
    a DOM element before or after another element
*/

taskName = "2. Insert element to DOM";

function Main(bufferElement) {
    var middleElement = createMiddleElement(bufferElement);
    $(bufferElement).append(middleElement);

    SetSolveButton(function () {
        InsertModule.insertBefore(middleElement);
    }, "Insert Before");

    SetSolveButton(function () {
        InsertModule.insertAfter(middleElement);
    }, "Insert After");
}

var InsertModule = (function() {
    function insertBefore(element) {
        insertElement(element, 'insertBefore');
    }

    function insertAfter(element) {
        insertElement(element, 'insertAfter');
    }

    function insertElement(element, action) {
        $('<div class="square inserted" />')[action]($('#middleElement'));
    }

    return {
        insertBefore: function(element) { insertBefore(element); }, 
        insertAfter: function(element) { insertAfter(element); }
    }
}());

function createMiddleElement(bufferElement) {
    var div = $('<div/>');
    $(div).addClass('square');
    $(div).attr('id', 'middleElement');

    return div;
}

