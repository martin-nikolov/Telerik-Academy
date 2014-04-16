/*
    4. *Wrap the TreeView from the previous presentation into a module.
*/

taskName = "4. Tree View Module";

function Main(bufferElement) {
    SetConsoleSize(500, 500);

    var controls = treeViewModule();
    var treeView = controls.treeView("div.tree-view");

    var jsnode = treeView.addNode("JavaScript");

    var js1subnode = jsnode.addNode("JavaScript - part 1");
    js1subnode.addNode("Operators and Expressions");
    js1subnode.addNode("Conditional Statements");
    js1subnode.addNode("Loops");
    js1subnode.addNode("Arrays");
    js1subnode.addNode("Functions");
    js1subnode.addNode("Using Objects");
    js1subnode.addNode("Strings");

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

    function _createUl(li) {
        return document.createElement('ul');
    }

    function _createLi(child) {
        var li = document.createElement('li');

        if (child) {
            li.appendChild(child);
        }

        return li;
    }

    function _createAnchor(content) {
        var anchor = document.createElement('a');
        anchor.expanded = false;

        if (content) {
            anchor.innerHTML = content;
        }

        // Set event to anchor
        anchor.onclick = function() {
            var children = anchor.nextElementSibling;

            if (children) {
                children.style.display =  this.expanded ? 'none' : 'block';
            }

            this.expanded = !this.expanded;
        }

        return anchor;
    }

    function treeView(wrapper) {
        var mainContainer = _GetDefaultContainer();
        var treeView = _createUl();

        if (wrapper) {
            var wrapperElement = _createWrapper(wrapper);
            wrapperElement.appendChild(treeView);
            mainContainer.appendChild(wrapperElement);
        }
        else {
            mainContainer.appendChild(treeView);
        }     

        return { 
            addNode: function(content) { return addNode(treeView, content); }
        }
    }

    function addNode(treeView, content) {
        var anchor = _createAnchor(content);
        var li = _createLi(anchor);

        if (treeView.tagName === "LI") {
            var ul = treeView.getElementsByTagName('ul')[0] || _createUl();
            ul.appendChild(li);
            treeView.appendChild(ul);
        }
        else if (treeView.tagName === "UL") {
            treeView.appendChild(li);
        }

        return {
            addNode: function(content) { return addNode(li, content); },
            content: function(content) { anchor.innerHTML = content || ""; }
        }
    }

    return { 
        treeView: function(wrapper) { return treeView(wrapper); } 
    }
}