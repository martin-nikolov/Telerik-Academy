 window.onload = function () {
     var bookDetailsContainer,
         bookDetailsTemplate,
         booksListContainer,
         booksListTemplate,
         books;
     books = [{
         id: 1,
         title: 'JavaScript: The Good parts',
         isbn: '0596517742',
         description: 'Most programming languages contain good and bad parts, but JavaScript has more than its share of the bad, having been developed and released in a hurry before it could be refined. This authoritative book scrapes away these bad features to reveal a subset of JavaScript that\'s more reliable, readable, and maintainable than the language as a whole—a subset you can use to create truly extensible and efficient code. Considered the JavaScript expert by many people in the development community, author Douglas Crockford identifies the abundance of good ideas that make JavaScript an outstanding object-oriented programming language-ideas such as functions, loose typing, dynamic objects, and an expressive object literal notation. Unfortunately, these good ideas are mixed in with bad and downright awful ideas, like a programming model based on global variables.',
         publicationDate: 'May 2008',
         author: 'Douglas Crockford'
     }, {
         id: 2,
         title: 'Secrets of the JavaScript Ninja',
         isbn: '193398869X',
         description: 'Secrets of the Javascript Ninja takes you on a journey towards mastering modern JavaScript development in three phases: design, construction, and maintenance. Written for JavaScript developers with intermediate-level skills, this book will give you the knowledge you need to create a cross-browser JavaScript library from the ground up.',
         publicationDate: 'December 2012',
         author: 'John Resig'
     }, {
         id: 3,
         title: 'Core HTML5 Canvas: Graphics, Animation, and Game Development',
         isbn: '0132761610',
         description: 'This book is a painstakingly crafted, expertly written, code-fueled, no-nonsense deep dive into HTML5 Canvas printed in full color with syntax-highlighted code listings throughout.',
         publicationDate: 'May 2012',
         author: 'David Geary'
     }, {
         id: 4,
         title: 'JavaScript Patterns',
         isbn: '0596806752',
         description: 'What\'s the best approach for developing an application with JavaScript? This book helps you answer that question with numerous JavaScript coding patterns and best practices. If you\'re an experienced developer looking to solve problems related to objects, functions, inheritance, and other language-specific categories, the abstractions and code templates in this guide are ideal—whether you\'re using JavaScript to write a client-side, server-side, or desktop application.',
         publicationDate: 'September 2010',
         author: 'Stoyan Stefanov'
     }];

     booksListContainer = document.getElementById('book-items-container');
     bookDetailsContainer = document.getElementById('book-details-container');

     booksListTemplate = Handlebars.compile((document.getElementById('books-list-template')).innerHTML);
     bookDetailsTemplate = Handlebars.compile((document.getElementById('book-details-template')).innerHTML);

     //empty the booksListContainer
     while (booksListContainer.firstChild) {
         booksListContainer.removeChild(booksListContainer.firstChild);
     }

     booksListContainer.innerHTML = booksListTemplate({
         books: books
     });
     //initially show the first book in the list
     bookDetailsContainer.innerHTML = bookDetailsTemplate(books[0]);


     function findParentOfType(el, type, beforeEl) {
         var node;
         beforeEl = beforeEl || document.body;
         node = el;
         while (!(node instanceof type && node !== beforeEl)) {
             node = node.parentNode;
         }
         if (node instanceof type) {
             return node;
         }
         return null;
     }

     function findById(id, items) {
         var item,
             i;
         for (i = 0; i < items.length; i += 1) {
             item = items[i];
             if (item.id === id) {
                 return item;
             }
         }
         return null;
     }

     function showBookDetails(id) {
         var book;
         book = findById(id, books);
         bookDetailsContainer.innerHTML = bookDetailsTemplate(book);
     }
     booksListContainer.addEventListener('click', function (ev) {
         var bookItem, target;
         ev = ev || window.event;
         target = ev.target;
         ev.preventDefault();
         bookItem = findParentOfType(target, HTMLAnchorElement, booksListContainer);
         if (bookItem === null) {
             return false;
         }
         showBookDetails(Number(bookItem.getAttribute('data-id')));
     });
 };