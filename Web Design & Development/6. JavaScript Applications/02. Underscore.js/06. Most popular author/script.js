/*
    6. By a given collection of books, find the most
    popular author (the author with the biggest number of books)
*/

taskName = "6. Most popular author";

function Main(bufferElement) {
    var booksCount = 10;
    var randomBooks = Library.BooksGenerator.getRandomBooks(booksCount);
    WriteLine('-- Random books --');
    printBooks(randomBooks);

    WriteLine();

    var mostPopularAuthors = findMostPopularAuthor(randomBooks);
    WriteLine(Format('Most popular author(s): {0} - {1} book(s)',
        mostPopularAuthors.join(', '), mostPopularAuthors.booksCount));
}

function findMostPopularAuthor(books) {
    var authorBooks = {};
    _.each(books, function(book) {
        authorBooks[book.authorName] = (authorBooks[book.authorName] || 0) + 1;
    });
    var mostPopularCount = _.max(authorBooks);

    var mostPopularAuthors = [];
    mostPopularAuthors.booksCount = mostPopularCount;
    _.each(authorBooks, function(count, authorName) {
        if (count === mostPopularCount) {
            mostPopularAuthors.push(authorName);
        }
    });
    return mostPopularAuthors;
}

function printBooks(books) {
    _.each(books, function(book) {
        WriteLine(book.toString());
    });
}