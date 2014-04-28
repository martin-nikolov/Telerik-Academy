<?php
$title = "Add new book";
require "includes/config.php";
require "includes/header.php";

// Заявка за извлизаче на ID и имената на авторите
$sql = 'SELECT author_id, author_name FROM authors ORDER BY author_name ASC';
$query = mysqli_query($CONNECTION, $sql);
if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

$isExistAuthors = FALSE;
?>

    <!-- Главно меню -->

    <a href="index.php">Book Catalog</a> | <b>New Book</b> | <a href="new-author.php">New Author</a><br><br>

    <form action="new-book.php" method="POST">
        <div> Book's title: <input type="text" name="book_title" required="" size="50" maxlength="70"/></div>
        <br>

        <!--Форма за избиране на повече от един автор-->

        <?php
        if (mysqli_affected_rows($CONNECTION))
        {
            $isExistAuthors = TRUE;
            echo '<div>Choose author:</div>';
            echo '<select name="selected_authors[]" size="15px" required="" multiple>';
            while ($row = $query->fetch_assoc())
            {
                echo '<option value = "' . $row['author_id'] . '">' . $row['author_name'] . '</option>';
            }
            echo ' </select><br><br>';
        }
        ?>

        <div><input type="submit" name="new-book" value="Add"/></div>
    </form>

<?php

if (isset($_POST['new-book']))
{
    // Нормализация на данните
    $book_title = trim($_POST['book_title']);
    $error = FALSE;

    // Валидация на данните
    if (mb_strlen($book_title, 'UTF-8') <= 3)
    {
        echo '<br><div class="error">- You have entered an invalid Book title!</div>';
        $error = TRUE;
    }

    if (!$error)
    {
        $book_title = htmlspecialchars(mysqli_real_escape_string($CONNECTION, $book_title));

        // Извличане на името на книгата
        $query = mysqli_query($CONNECTION, 'SELECT book_title FROM books WHERE book_title = "' . $book_title . '"');
        if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

        $isExistBook = mysqli_num_rows($query) >= 1 ? TRUE : FALSE; // Връща броя намерени автори с това име

        if ($isExistBook) // Проверка дали съществува книга с въведеното име
        {
            echo '<br><div class="error">- Book "' . $book_title . '" already exist!</div>';
        }
        else // Добавяме книгата и я свързваме с нейните автори
        {
            // Добавяме книгата към базата данни
            $sql = 'INSERT INTO books (book_title) VALUE ("' . $book_title . '");';
            $query = mysqli_query($CONNECTION, $sql);
            if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

            $book_id = mysqli_insert_id($CONNECTION);

            // Ако не са добавени автори -> създаваме книга без автор
            if ($isExistAuthors)
            {
                $author_id = NULL;
                $sql = 'INSERT INTO books_authors (book_id, author_id) VALUE ("' . $book_id . ', ' . $author_id . '");';
                $authors = $_POST['selected_authors'];

                for ($i = 0; $i < count($authors); $i++)
                {
                    $author_id = $authors[$i];
                    $sql = 'INSERT INTO books_authors (book_id, author_id) VALUE (' . $book_id . ', ' . $author_id . ');';
                    $query = mysqli_query($CONNECTION, $sql);
                    if (HasErrorWithDataBase($query)) exit; // Проверка за грешки
                }
            }
            else
            {
                $sql = 'INSERT INTO books_authors (book_id) VALUE (' . $book_id . ');';
                $query = mysqli_query($CONNECTION, $sql);
                if (HasErrorWithDataBase($query)) exit; // Проверка за грешки
            }

            echo '<br><div class="success">- You have successfully added book: "' . $book_title . '" !' . '</div>';
        }
    }
}

?>

<?php include "includes/footer.php"; ?>