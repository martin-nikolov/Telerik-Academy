<?php
$title = "Add new author";
require "includes/config.php";
require "includes/header.php";

$sql = 'SELECT author_name FROM authors ORDER BY author_name ASC';
$query = mysqli_query($CONNECTION_BOOKS, $sql);
if (HasErrorWithDataBase($query)) exit; // Проверка за грешки
?>

    <!-- Главно меню -->

    <div style="float: left; padding-top: 2px"><a href="index.php">Book Catalog</a> | <a href="new-book.php">New Book</a> | <b>New
            Author</b></div>
    <div style="float: right;"><?php ShowHelloScreen(); ?></div>

    <!--Форма за добавяне на нов автор-->

    <br><br>
    <form action="new-author.php" method="POST">
        <div>
            Author's name: <input type="text" name="author_name" required="" size="50" maxlength="50"/>
            <input type="submit" name="new-author" value="Add"/>
        </div>
    </form>
    <br>

    <!--Таблица с добавените автори-->

    <table border="1" cellpadding="5" cellspacing="0">
        <tr>
            <td align="center"><b>Added authors:</b></td>
        </tr>
        <?php
        if (mysqli_affected_rows($CONNECTION_BOOKS))
        {
            while ($row = $query->fetch_assoc())
            {
                echo '<tr><td><a href="index.php?author=' . $row['author_name'] . '">';
                echo $row['author_name'] . '</a></td></tr>';
            }
        }
        else
        {
            echo '<tr><td><span class="error">- Няма добавени автори!</span></td></tr>';
        }
        ?>
    </table>

<?php

if (isset($_POST['new-author']))
{
    // Нормализация на данните
    $author = trim($_POST['author_name']);
    $error = FALSE;

    // Валидация на данните
    if (mb_strlen($author, 'UTF-8') <= 3)
    {
        echo '<br><div class="error">- You have entered an invalid Author name!</div>';
        $error = TRUE;
    }

    if (!$error)
    {
        $author = htmlspecialchars(mysqli_real_escape_string($CONNECTION_BOOKS, $author));

        // Извличане на името на автора
        $query = mysqli_query($CONNECTION_BOOKS, 'SELECT author_name FROM authors WHERE author_name = "' . $author . '"');
        if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

        $isExistAuthor = mysqli_num_rows($query) >= 1 ? TRUE : FALSE; // Връща броя намерени автори с това име

        if ($isExistAuthor) // Проверка дали съществува автор с въведеното име
        {
            echo '<br><div class="error">- Author "' . $author . '" already exist!</div>';
        }
        else // Добавяме автора към базата данни
        {
            $sql = 'INSERT INTO authors (author_name) VALUE ("' . $author . '");';
            $query = mysqli_query($CONNECTION_BOOKS, $sql);
            if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

            header('Location: new-author.php?new-author=' . $author);
        }
    }
}

if (isset($_GET['new-author']))
{
    echo '<br><div class="success">- You have successfully added author: "' . $_GET['new-author'] . '" !' . '</div>';
}
?>

<?php include "includes/footer.php"; ?>