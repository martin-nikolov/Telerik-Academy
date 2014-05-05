/*
    12. Write a function that creates a HTML UL using
    a template for every HTML LI. The source of the 
    list should an array of elements. Replace all 
    placeholders marked with –{…}–   with the value 
    of the corresponding property of the object. Example: 
    
    <div data-type="template" id="list-item">
        <strong>-{name}-</strong> <span>-{age}-</span>
    /div>
*/

taskName = "12. Generate list by template";

function Main(bufferElement) {

    var women =
    [
        { name: "Aleksandrina", age: 20 },
        { name: "Stela", age: 25 },
        { name: "Monika" }, // has no age
        { name: "Svetla", age: 23 }
    ];

    var template = document.getElementById("list-item").innerHTML;

    generateList(women, template, bufferElement);
}

function generateList(collection, template, toHtmlElement) {
    var ul = document.createElement('ul');

    for (var i = 0; i < collection.length; i++) {

        var li = document.createElement('li');
        li.innerHTML = generateListItemContent(collection[i], template);
        ul.appendChild(li);
    }

    toHtmlElement.appendChild(ul);
}

function generateListItemContent(obj, template) {
    var selfArguments = arguments;

    return template.replace(/\-{(\w+)\}-/g, function (match, arg) {
        return obj[arg] || "";
    });
}