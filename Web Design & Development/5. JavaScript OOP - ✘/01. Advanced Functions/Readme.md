## Advanced Functions

1. Create a module for working to work with DOM. The module should have the following functionality
    * Add element to parent element by given selector
    * Remove element from the DOM  by given selector
    * Attach event to given selector by given event type and event hander
    * Add elements to buffer, which appends them to the DOM when their for some selector count becomes 100
        * The buffer contains elements for each selector it gets
    * Get elements by CSS selector
    * The module should reveal only the methods

    The module should have the following functionality:

    ```js
    var domModule = ...;
    var div = document.createElement("div");

    // Change the div
    domModule.appendChild(div, "#wrapper");
    domModule.removeChild("ul", "li:first");

    // Remove the first li from each ul
    domModule.addHandler("a.button", "click", function(){
        alert("Clicked");
    });

    domModule.appendToBuffer("container", div.cloneNode(true));
    domModule.appendToBuffer("#main-nav ul", navItem);
    ```
* Create a module that works with moving div elements. Implement functionality for:
    * Add new moving div element to the DOM
        * The module should generate random `background`, `font` and `border-color`
        * All the div elements are with the same `width` and `height`
    * The movements of the div elements can be either circular or rectangular
    * The elements should be moving all the time

    ```js
    var movingShapes = ...;

    // Add element with rectangular movement
    movingShapes.add("rect");

    // Add element with ellipse movement
    movingShapes.add("ellipse");
    ```
* Create a module to work with the `console` object. Implement functionality for:
    * Writing a line to the `console`
    * Writing a line to the `console` using a format
    * Writing to the console should call `toString()` to each element
    * Writing errors and warnings to the `console` with and without format

    ```js
    var specialConsole = ...;

    //logs to the console "Message: hello"
    specialConsole.writeLine("Message: hello");

    //logs to the console "Message: hello"
    specialConsole.writeLine("Message: {0}", "hello");

    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");
    ```
* \* Wrap the TreeView from the previous presentation into a module

    ```js
    var controls = ...;
    var treeView = controls.treeView("div.tree-view");

    var jsnode = treeView.addNode();
    jsnode.content("JavaScript");

    var js1subnode = jsnode.addNode();
    js1subnode.content("JavaScript - part 1");

    var js2subnode = jsnode.addNode();
    hs2subnode.content("JavaScript - part 2");

    var jslibssubnode = jsnode.addNode();
    jslibssubnode.content("JS Libraries");

    var jsframeworksnode = jsnode.addNode();
    jsframeworksnode.content("JS Frameworks and UI");

    var webnode = treeView.addNode();
    webnode.content("Web");
    ```

   The code should generate:

   ```html
   <div class="tree-view">
     <ul>
       <li><a href="#">JavaScript</a>
         <ul>
           <li><a href="#">JavaScript - part 1</a></li>
           <li><a href="#">JavaScript - part 2</a></li>
           <li><a href="#">JS Libraries</a></li>
           <li><a href="#">JS Frameworks and UI</a></li>
         </ul>
       </li>
       <li><a href="#">Web</a></li>
     </ul>
   </div>
   ```