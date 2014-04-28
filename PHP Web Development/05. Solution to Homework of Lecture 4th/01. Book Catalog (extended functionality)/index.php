<?php
$title = "Book Catalog";
require "includes/config.php";
require "includes/header.php";

// Заявка за връзка книга - автор(и)
$sql = 'SELECT books.book_id, books.book_title, books.comments_count, authors.author_name
        FROM books
        LEFT JOIN books_authors ON books.book_id = books_authors.book_id
        LEFT JOIN authors ON authors.author_id = books_authors.author_id';

if (isset($_GET['author'])) // Задали сме филтър по автор
{
    $author = htmlspecialchars(mysqli_real_escape_string($CONNECTION_BOOKS, $_GET['author']));
    $sql .= ' WHERE books.book_title
              IN (SELECT books.book_title
              FROM books
              LEFT JOIN books_authors ON books.book_id = books_authors.book_id
              LEFT JOIN authors ON authors.author_id = books_authors.author_id
              WHERE author_name="' . $author . '")';
}
else if (isset($_GET['search_by_book_title']))
{
    $bookTitle = $_GET['search_by_book_title'];
    $sql .= ' WHERE book_title LIKE "%' . $bookTitle . '%"';
}

if (isset($_GET['ORDER_by_book_title']) && ($_GET['ORDER_by_book_title'] == 'ASC' || $_GET['ORDER_by_book_title'] == 'DESC'))
{
    $order = $_GET['ORDER_by_book_title'];
    $sql .= ' ORDER BY book_title ' . $order;
}
else if (isset($_GET['ORDER_by_author_name']) && ($_GET['ORDER_by_author_name'] == 'ASC' || $_GET['ORDER_by_author_name'] == 'DESC'))
{
    $order = $_GET['ORDER_by_author_name'];
    $sql .= ' ORDER BY author_name ' . $order;
}
else
{
    unset($_GET['ORDER_by_author_name']);
    unset($_GET['ORDER_by_book_title']);
    $order = 'DESC';
    $sql .= ' ORDER BY book_title ' . $order;
}

$query = mysqli_query($CONNECTION_BOOKS, $sql);
if (HasErrorWithDataBase($query)) exit; // Проверка за грешки
?>

    <!-- Главно меню -->

    <div style="float: left; padding-top: 2px">
        <?php
        echo (isset($_GET['ORDER_by_book_title']) || isset($_GET['ORDER_by_author_name'])) ?
            '<a href="index.php">Book Catalog</a>' : '<b>Book Catalog</b>';

        echo ' | <a href="new-book.php">New Book</a> | <a href="new-author.php">New Author</a> | ';

        // Линк за сортиране ASC/DESC по името на книгата
        $link = isset($_GET['ORDER_by_book_title']) && $_GET['ORDER_by_book_title'] == 'ASC' ? 'DESC' : 'ASC';
        echo '<a href="?ORDER_by_book_title=' . $link . '">';
        echo (isset($_GET['ORDER_by_book_title']) && $_GET['ORDER_by_book_title'] == 'ASC' ? 'DESC by Book title' : 'ASC by Book title') . '</a> | ';

        // Линк за сортиране ASC/DESC по името на автора
        $link = isset($_GET['ORDER_by_author_name']) && $_GET['ORDER_by_author_name'] == 'ASC' ? 'DESC' : 'ASC';
        echo '<a href="?ORDER_by_author_name=' . $link . '">';
        echo (isset($_GET['ORDER_by_author_name']) && $_GET['ORDER_by_author_name'] == 'ASC' ? 'DESC by Author name' : 'ASC by Author name') . '</a>';
        ?>
        |&nbsp;
    </div>
    <div style="float: right;"><?php ShowHelloScreen(); ?></div>
    <form action="index.php" method="GET">
        <input type="text" name="search_by_book_title" placeholder="Search by book name"/>
        <input type="submit" value="Search"/>
    </form>

    <br>

<?php

if (isset($_GET['author']) || isset($_GET['search_by_book_title']))
    echo '<div>- <a href="index.php">Back to Book Catalog</a></div><br>';

if (!mysqli_affected_rows($CONNECTION_BOOKS))
{
    echo '<span class="error">- There are no added books' . (isset($_GET['search_by_book_title']) ? ' containing this word!' : '!') . '!</span>';
    exit;
}

// Съобщение, че книгите са сортирани по техните имена
if (isset($_GET['ORDER_by_book_title']))
{
    echo '<div class="success">- All books sorted by THEIR TITLES in <strong>';
    echo $_GET['ORDER_by_book_title'] . 'ENDING </strong> ORDER...</div><br>';
}
else if (isset($_GET['search_by_book_title']))
{
    echo '<div class="success">- All books with title "' . $_GET['search_by_book_title'] . '"...</div><br>';
}

// Съобщение, че книгите са сортирани по имената на техните автори
if (isset($_GET['ORDER_by_author_name']))
{
    echo '<div class="success">- All books sorted by their AUTHORS NAMES in <strong>';
    echo $_GET['ORDER_by_author_name'] . 'ENDING </strong> ORDER...</div><br>';
}

// Масив[][име_на_книга][авторите_на_книгата]
$books = array();
while ($row = $query->fetch_assoc())
{
    $books[$row['book_id']]['book_id'] = $row['book_id'];
    $books[$row['book_id']]['comments_count'] = $row['comments_count'];
    $books[$row['book_id']]['book_title'] = $row['book_title'];
    $books[$row['book_id']]['authors'][] = $row['author_name'];
}
?>

    <!--Таблица с книгите и техните автори-->

    <table border="1" cellpadding="5" cellspacing="0">
        <tr align="center">
            <td><b>Book:</b></td>
            <td><b>Author(s):</b></td>
        </tr>
        <?php
        foreach ($books as $book)
        {
            echo '<tr><td><a href="book-info.php?book_id=' . $book['book_id'] . '">' . $book['book_title'] . '</a>';
            echo ' [' . $book['comments_count'] . ']</td><td>';
            for ($i = 0; $i < count($book['authors']); $i++)
            {
                echo '<a href="index.php?author=' . $book['authors'][$i] . '">';
                echo $book['authors'][$i] . '</a>';

                if ($i + 1 < count($book['authors'])) echo ', ';
            }
            echo '</td></tr>';
        }
        ?>
    </table>

<?php include "includes/footer.php"; ?>