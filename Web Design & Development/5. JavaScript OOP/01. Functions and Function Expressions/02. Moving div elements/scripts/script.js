/*
    2. Create a module that works with moving div elements. 
       Implement functionality for:

        - Add new moving div element to the DOM
            - The module should generate random background, font and border colors for the div element
            - All the div elements are with the same width and height
        - The movements of the div elements can be either circular or rectangular
        - The elements should be moving all the time
*/

window.onload = function() {
    var container = includeContainer();
    var movingShapes = new ShapeModule(container);

    movingShapes.add('circle');
    movingShapes.add('circle');
    movingShapes.add('rectangle');
    movingShapes.add('rectangle');
}

function includeContainer() {
    var container = $('<div/>')
        .css('position', 'absolute')
        .css('left', "300px")
        .css('top', "150px");

    $('#main-container').append(container);

    return {
        append: function(child) { container.append(child); }
    }
}