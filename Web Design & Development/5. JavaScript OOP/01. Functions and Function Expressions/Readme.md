## Functions and Function Expressions

1. Create a module for working with DOM. The module should have the following functionality
    * Add DOM element to parent element given by selector
    * Remove element from the DOM  by given selector
    * Attach event to given selector by given event type and event hander
    * Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
    * The buffer contains elements for each selector it gets
    * Get elements by CSS selector
    * The module should reveal only the methods

   ```js
       var domModule = …
       var div = document.createElement("div");
   
       //appends div to #wrapper
       domModule.appendChild(div,"#wrapper"); 
   
       //removes li:first-child from ul
       domModule.removeChild("ul","li:first-child"); 
   
       //add handler to each a element with class button
       domModule.addHandler("a.button", 'click', function(){alert("Clicked")});
       domModule.appendToBuffer("container", div.cloneNode(true));
       domModule.appendToBuffer("#main-nav ul", navItem);
   ```
* Create a module that works with moving div nodes. Implement functionality for:
    * Add new moving div element to the DOM
        * The module should generate random background, font and border colors for the div element
        * All the div elements are with the same width and height
    * The movements of the div nodes can be either circular or rectangular
    * The elements should be moving all the time

   ```js
       var movingShapes = …
   
       //add element with rectangular movement
       movingShapes.add("rect"); 
   
       //add element with ellipse movement
       movingShapes.add("ellipse");
   ```
* Create a module to work with the console object. Implement functionality for:
    * Writing a line to the console 
    * Writing a line to the console using a format
    * Writing to the console should call toString() to each element
    * Writing errors and warnings to the console with and without format

   ```js
       var specialConsole = …
       specialConsole.writeLine("Message: hello");
       specialConsole.writeLine("Message: {0}", "hello");
       specialConsole.writeError("Error: {0}", "Something happened");
       specialConsole.writeWarning("Warning: {0}", "A warning");
   ```
