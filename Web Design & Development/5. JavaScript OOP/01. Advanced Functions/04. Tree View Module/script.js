/*
    4. *Wrap the TreeView from the previous presentation into a module.
*/

taskName = "4. Tree View Module";

function Main(bufferElement) {
    SetConsoleSize(500, 500);

    var controls = treeViewModule();
    var treeView = controls.treeView("div.tree-view");

    var jsnode = treeView.addNode();
    jsnode.content("JavaScript");

    var js1subnode = jsnode.addNode();
    js1subnode.content("JavaScript - part 1");

    var js2subnode = jsnode.addNode();
    js2subnode.content("JavaScript - part 2");

    var jslibssubnode = jsnode.addNode();
    jslibssubnode.content("JS Libraries");

    var jsframeworksnode = jsnode.addNode();
    jsframeworksnode.content("JS Frameworks and UI");

    var webnode = treeView.addNode();
    webnode.content("Web");
}

function treeViewModule() {

    function _createWrapper(params) {
        var wrapperType, wrapperClass;
        var pointIndex = params.indexOf('.');

        if (pointIndex != -1) {
            wrapperClass = params.substr(pointIndex);
            wrapperClass = wrapperClass.replace(/\./gi, function() { return ' '; }).substr(1);

            wrapperType = params.substr(0, pointIndex);
        }

        var wrapper = document.createElement(wrapperType || params);
        wrapper.className = wrapperClass || null;

        return wrapper;
    }

    function _createTreeView(liCount, message, isSubItem) {
        var list = document.createElement('ul');
        message = message || "Item";

        for (var i = 0; i < liCount; i++) {
            var li = list.addNode(message);
            list.appendChild(li);
        }

        if (isSubItem) {
            list.style.display = 'none';
        }

        return list;
    }

    function treeView(wrapper) {
        var mainContainer = _GetDefaultContainer();
        var treeView = document.createElement('ul');

        if (wrapper) {
            var wrapperElement = _createWrapper(wrapper);
            wrapperElement.appendChild(treeView);
            mainContainer.appendChild(wrapperElement);
        }
        else {
            mainContainer.appendChild(treeView);
        }     

        function addNode() {
            var anchor = document.createElement('a');
            anchor.expanded = false;

            // Set event to anchor
            anchor.onclick = function() {
                var children = anchor.nextElementSibling;

                if (children) {
                    children.style.display =  this.expanded ? 'none' : 'block';
                }

                this.expanded = !this.expanded;
            }

            var li = document.createElement('li');
            li.appendChild(anchor);

            treeView.appendChild(li);

            return {
                this: function() { return li; },
                content: function(content) { anchor.innerHTML = content; }
            }
        }

        return { 
            this: function() { return treeView; }, 
            addNode: function() { return addNode(); }
        }
    }

    return { 
        treeView: function(wrapper) { return treeView(wrapper); } 
    }
}