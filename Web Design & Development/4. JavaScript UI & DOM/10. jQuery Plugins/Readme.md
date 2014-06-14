## jQuery Plugins

1. Create a jQuery plugin for creating dropdown list
  * By given the following:

  ```html
    <select id="dropdown">
      <option value="1">One</option>
      <option value="2">Two</option>
    </select>
  ```
  
  `$('#dropdown').dropdown();`
  * Produces the following HTML:
  ```html
    <select id="dropdown" style="display: none">…</select>
    <div class="dropdown-list-container">
      <ul class="dropdown-list-options">
        <li class="dropdown-list-option" data-value="0">One</li>
        …
      </ul>
    </div>
  ```
  * And make it work as SELECT node
    * Selecting an one of the generated LI nodes, selects the corresponding OPTION node
      * So `$('#dropdown:selected')` works 

2. *Create a jQuery plugin for fading in/fading out message box
  * Creates a message box

  ```js
  var msgBox = $('#message-box').messageBox();
  ```

  * Show a success/error message in the box
    * Showing is done by setting the opacity of the message from 0 to 1 in an interval of 1 second
    * The message disappears after 3 seconds

  ```js
    msgBox.success('Success message');
    msgBox.error('Error message');
  ```
