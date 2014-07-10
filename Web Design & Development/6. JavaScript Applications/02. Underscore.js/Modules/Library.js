var Library = (function() {
    'use strict';

    var Book = (function() {
        var _id = 1;

        function Book(title, authorName) {
            this.id = _id++;
            this.title = title;
            this.authorName = authorName;
            return this;
        }

        Book.prototype.toString = function() {
            return '"' + this.title + '" - ' + this.authorName;
        };

        return Book;
    }());

    var BooksGenerator = (function() {
        var books = [
            new Book('The Count of Monte Cristo', 'Alexandre Dumas'),
            new Book('The Three Musketeers', 'Alexandre Dumas'),
            new Book('The Man in the Iron Mask', 'Alexandre Dumas'),
            new Book('Twenty Years After', 'Alexandre Dumas'),
            new Book('The Black Tulip', 'Alexandre Dumas'),
            new Book('The Da Vinci Code', 'Dan Brown'),
            new Book('Digital Fortress', 'Dan Brown'),
            new Book('Deception Point', 'Dan Brown'),
            new Book('Hamlet', 'William Shakespeare'),
            new Book('Romeo and Juliet', 'William Shakespeare'),
            new Book('Othello', 'William Shakespeare'),
            new Book('A Study in Scarlet', 'Sir Arthur Conan Doyle'),
            new Book('The Hound of the Baskervilles', 'Sir Arthur Conan Doyle'),
            new Book('The Adventures of Sherlock Holmes', 'Sir Arthur Conan Doyle'),
            new Book('The Memoirs of Sherlock Holmes', 'Sir Arthur Conan Doyle'),
            new Book('A Game of Thrones: A Song of Ice and Fire', 'George R. R. Martin'),
            new Book('A Dance with Dragons: A Song of Ice and Fire', 'George R. R. Martin'),
            new Book('A Clash of Kings: A Song of Ice and Fire', 'George R. R. Martin'),
            new Book('A Feast for Crows: A Song of Ice and Fire', 'George R. R. Martin'),
            new Book('Mr. Mercedes', 'Stephen King'),
            new Book('Doctor Sleep', 'Stephen King'),
            new Book('11/22/63', 'Stephen King'),
            new Book('Joyland', 'Stephen King'),
            new Book('The Shining', 'Stephen King')
        ];

        function _getRandomBooks(count) {
            count = count || books.length;
            var randomBooks = {},
                randomBook, selectedBooksCount = 0;

            while (selectedBooksCount != count && selectedBooksCount < books.length) {
                randomBook = books[GetRandomInt(0, books.length - 1)];
                if (!randomBooks[randomBook.id]) {
                    selectedBooksCount++;
                }
                randomBooks[randomBook.id] = randomBook;
            }

            return _.shuffle(randomBooks);
        }

        return {
            getRandomBooks: _getRandomBooks
        };
    }());

    return {
        Book: Book,
        BooksGenerator: BooksGenerator
    };
}());