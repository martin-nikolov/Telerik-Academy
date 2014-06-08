/*
    5. *Create a TreeView component
    - Initially only the top items must be visible
    - On item click
        - If its children are hidden (collapsed), they must be made visible (expanded)
        - If its children are visible (expanded), they must be made hidden (collapsed)
    - Research about events
*/

taskName = "5. Tree View";

function Main(bufferElement) {
    SetConsoleSize(500, 500);

    var numberOfNodes = 5;
    createTreeView(numberOfNodes);
}

function createTreeView(numberOfNodes) {
    var list = createList(numberOfNodes);
    addNestedList(list);
}

function createList(liCount, message, isSubItem) {
    var mainContainer = _GetDefaultContainer();
    var list = document.createElement('ul');
    message = message || "Item";

    for (var i = 0; i < liCount; i++) {
        var li = createListItem(message);
        list.appendChild(li);
    }

    if (isSubItem) {
        list.style.display = 'none';
    }

    mainContainer.appendChild(list);

    return list;
}

function createListItem(message) {
    var anchor = document.createElement('a');
    anchor.expanded = false;
    anchor.innerHTML = message;

    // Set event to anchor
    anchor.onclick = function() {
        var children = anchor.nextElementSibling;

        if (children) {
            children.style.display = this.expanded ? 'none' : 'block';
        }

        this.expanded = !this.expanded;
    };

    var li = document.createElement('li');
    li.appendChild(anchor);

    return li;
}

function addNestedList(list) {
    list.firstChild.appendChild(createList(1, "Sub item", true));
    list.firstChild.lastChild.lastChild.appendChild(createList(2, "Sub item", true));
    list.firstChild.lastChild.lastChild.lastChild.lastChild.appendChild(createList(3, "Sub item", true));
    list.firstChild.lastChild.lastChild.lastChild.lastChild.lastChild.lastChild.appendChild(createList(3, "Sub item", true));

    list.firstChild.nextElementSibling.appendChild(createList(2, "Sub item", true));
    list.firstChild.nextElementSibling.lastChild.firstChild.appendChild(createList(2, "Sub item", true));
    list.firstChild.nextElementSibling.lastChild.lastChild.appendChild(createList(2, "Sub item", true));
}