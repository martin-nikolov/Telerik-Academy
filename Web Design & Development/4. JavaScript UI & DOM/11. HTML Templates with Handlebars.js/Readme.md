## HTML Templates with Handlebars.js

1. Create the following using Handlebars.js

    ![Screenshot](https://raw.githubusercontent.com/flextry/Telerik-Academy/master/Web%20Design%20&%20Development/4.%20JavaScript%20UI%20&%20DOM/11.%20HTML%20Templates%20with%20Handlebars.js/01.%20Simple%20table/index.png)

2. Create a dynamic select using Handlebars.js
    * The options in the select should be generated based on a collection of JavaScript objects
    * Example:

    ![Screenshot](https://raw.githubusercontent.com/flextry/Telerik-Academy/master/Web%20Design%20&%20Development/4.%20JavaScript%20UI%20&%20DOM/11.%20HTML%20Templates%20with%20Handlebars.js/02.%20Select%20menu/index.png)

    ```js
        var items = [{
            value: 1,
            text: 'One'
        }, {
            value: 2,
            text: 'Two'
        }, {
            value: 3,
            text: 'Three'
        }];
    
        var selectHTML = selectTemplate(items);
    ```

3. *Create a jQuery plugin for ListView
    * Apply a template for each item of a collection
    * Using the data-template attribute set the ID of the template to use for the items
    * Must work with different collections and templates

    ![Screenshot](https://raw.githubusercontent.com/flextry/Telerik-Academy/master/Web%20Design%20&%20Development/4.%20JavaScript%20UI%20&%20DOM/11.%20HTML%20Templates%20with%20Handlebars.js/03.%20ListView/example-1.png) 

    ```html
        <ul id="books-list" data-template="book-item-template"></ul>

        <script id="book-item-template" type="text/x-handlebars-template">
            <li class="book-item">
                <a href="/#books/{{id}}">
                    <strong>{{title}}</strong>
                </a>
            </li> 
        </script>
    ```
    
    `$('#books-list').listview(books);` 
    
    ![Screenshot](https://raw.githubusercontent.com/flextry/Telerik-Academy/master/Web%20Design%20&%20Development/4.%20JavaScript%20UI%20&%20DOM/11.%20HTML%20Templates%20with%20Handlebars.js/03.%20ListView/example-2.png)
    
    ```html
        <table>
            <thead>
                <tr><th>#</th><th>Name</th><th>Mark</th></tr>
            </thead>
                <tbody id="students-table" data-template="students-row-template">   
            </tbody>
        </table>

        <script id="students-row-template" type="text/x-handlebars-template">
            <tr class="student-row">
                <td>{{number}}</td>
                <td>{{name}}</td>
                <td>{{mark}}</td>
            </tr>
        </script>
    ```
    
    `$('#students-table').listview(students);`
    
4. *Extend the previous task to set the template inside the DOM element, instead of setting it with data-template

    ```html
        <table>
            <thead>
                <tr><th>#</th><th>Name</th><th>Mark</th></tr>
            </thead>
            <tbody id="students-table">
                <tr class="student-row">
                    <td>{{number}}</td>
                    <td>{{name}}</td>
                    <td>{{mark}}</td>
                </tr>       
            </tbody>
        </table>
    ```
    
    `$('#students-table').listview(students);`
